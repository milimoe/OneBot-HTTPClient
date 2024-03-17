using Milimoe.FunGame.Core.Api.Utility;

namespace Milimoe.OneBot.Framework.Utility
{
    public class PluginConfig<TKey, TValue>(string plugin_name, string file_name) : Dictionary<TKey, TValue> where TKey : notnull
    {
        public string plugin_name { get; set; } = plugin_name;
        public string file_name { get; set; } = file_name;

        private readonly Dictionary<TKey, TValue> _config = [];

        public new TValue? this[TKey key]
        {
            get
            {
                if (_config.TryGetValue(key, out TValue? value)) return value;
                return default;
            }
            set => AddConfig(key, value);
        }

        public void AddConfig(TKey key, TValue? value)
        {
            if (value != null)
            {
                _config.Remove(key);
                _config.Add(key, value);
            }
        }

        public void LoadConfig()
        {
            TXTHelper.ReadTXT(file_name, plugin_name);
        }

        public void SaveConfig()
        {
            string json = JsonTools.GetString(_config);
            string path = $@"{AppDomain.CurrentDomain.BaseDirectory}{plugin_name}";
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            TXTHelper.WriteTXT(json, file_name, plugin_name);
        }
    }
}
