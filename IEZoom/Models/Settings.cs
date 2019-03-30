using System.IO;
using System.Reflection;
using Newtonsoft.Json;

namespace IEZoom.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class Settings
    {
        /// <summary></summary>
        private static readonly string _settingsPath;
        /// <summary>
        /// 
        /// </summary>
        static Settings()
        {
            string dir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            _settingsPath = Path.Combine(dir, "settings.json");
        }
        /// <summary>
        /// 
        /// </summary>
        private Settings()
        {
        }
        /// <summary></summary>
        public int Percent = 82;
        /// <summary></summary>
        public string Filter = "";
        /// <summary></summary>
        public bool IsAutoZoom = false;
        /// <summary></summary>
        [JsonIgnore]
        public bool IsChanged { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static Settings Load()
        {
            if (!File.Exists(_settingsPath))
            {
                return new Settings();
            }

            string json = File.ReadAllText(_settingsPath);
            Settings settings = JsonConvert.DeserializeObject<Settings>(json);
            return settings;
        }
        /// <summary>
        /// 
        /// </summary>
        public void Save()
        {
            string json = JsonConvert.SerializeObject(this);
            File.WriteAllText(_settingsPath, json);
            IsChanged = false;
        }
    }
}
