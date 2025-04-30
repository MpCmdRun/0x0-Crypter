using System;
using System.IO;
using Newtonsoft.Json;

namespace Crypter
{
    internal class Settings
    {
        private static string savepath = AppDomain.CurrentDomain.BaseDirectory + "\\bin\\settings.json";

        internal static SettingsObject Load()
        {
            if (!File.Exists(savepath))
            {
                return JsonConvert.DeserializeObject<SettingsObject>(File.ReadAllText(savepath));
            }
            return null;
        }

        internal static void Save(SettingsObject obj) => File.WriteAllText(savepath, JsonConvert.SerializeObject(obj, Formatting.Indented));
    }

    internal class SettingsObject
    {
        public string inputfile { get; set; }
        public bool antiVM { get; set; }
        public bool antiDebug { get; set; }
        public bool amsiBypass { get; set; }
        public bool etwBypass { get; set; }
        public bool obfuscation { get; set; }
        public bool runas { get; set; }
    }
}