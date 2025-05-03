using Mono.Cecil;
using Mono.Cecil.Cil;
using Mono.Cecil.Rocks;
using System;
using System.Linq;

namespace Crypter.Utils
{
    public class Obfuscator
    {
        static Random rng = new Random();

        public static void Obfuscate(string inputpath, string outputpath)
        {
            var asm = AssemblyDefinition.ReadAssembly(inputpath);
            foreach (var type in asm.MainModule.Types)
            {
                if (!type.IsClass || type.Name.StartsWith("<")) continue;

                foreach (var method in type.Methods.Where(m => m.HasBody))
                {
                    method.Name = RandomString(8);
                    ObfuscateControlFlow(method);
                }
            }

            asm.Write(outputpath);
        }

        private static void ObfuscateControlFlow(MethodDefinition method)
        {
            if (method.IsConstructor || method.Name == "Main")
            {
                return;
            }

            var il = method.Body.GetILProcessor();
            var instructions = method.Body.Instructions.ToList();

            if (instructions.Count <= 2)
                return;

            var rand = new Random();
            for (int i = 1; i < instructions.Count - 1; i += rand.Next(3, 6))
            { 
                OpCode branchOpCode;
                int branchChoice = rand.Next(0, 3);

                switch (branchChoice)
                {
                    case 0:
                        branchOpCode = OpCodes.Br_S; 
                        break;
                    case 1:
                        branchOpCode = OpCodes.Brfalse_S;
                        break;
                    default:
                        branchOpCode = OpCodes.Brtrue_S;  
                        break;
                }


                var br = il.Create(branchOpCode, instructions[i]);
                il.InsertBefore(instructions[i], br);
                if (rand.Next(0, 4) == 0)
                {
                    il.InsertBefore(instructions[i], il.Create(OpCodes.Nop));
                }
            }
            for (int i = 0; i < 3; i++)
            {
                var redundantOp = rand.Next(0, 2) == 0 ? OpCodes.Ldnull : OpCodes.Nop;
                il.InsertBefore(instructions[0], il.Create(redundantOp));
            }

            method.Body.OptimizeMacros();
        }


        private static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[rng.Next(s.Length)]).ToArray());
        }
    }
}
