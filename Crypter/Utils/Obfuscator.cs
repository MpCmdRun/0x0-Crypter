using Mono.Cecil;
using Mono.Cecil.Cil;
using Mono.Cecil.Rocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                    ObfuscateLocals(method);
                    ObfuscateControlFlow(method);
                }
            }

            asm.Write(outputpath);
        }

        private static void ObfuscateLocals(MethodDefinition method)
        {
            for (int i = 0; i < method.Body.Variables.Count; i++)
            {
                var variable = method.Body.Variables[i];
            }
        }

        private static void ObfuscateControlFlow(MethodDefinition method)
        {
            var il = method.Body.GetILProcessor();
            var instructions = method.Body.Instructions.ToList();
            if (instructions.Count > 2)
            {
                var nop = il.Create(OpCodes.Nop);
                il.InsertBefore(instructions[0], il.Create(OpCodes.Br_S, nop));
                il.InsertBefore(instructions[0], nop);
            }
            for (int i = 1; i < instructions.Count - 1; i += 5)
            {
                var br = il.Create(OpCodes.Br_S, instructions[i]);
                il.InsertBefore(instructions[i], br);
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
