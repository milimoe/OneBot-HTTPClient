using Config = Milimoe.FunGame.Core.Api.Utility.PluginConfig;

namespace Milimoe.OneBot.Framework.Utility
{
    public class PluginConfig(string plugin_name, string file_name)
    {
        public Config config { get; set; } = new(plugin_name, file_name);

        public object this[string key]
        {
            get => config[key];
            set => config[key] = value;
        }

        public void Add(string key, object value) => config.Add(key, value);

        public bool TryGetValue(string key, out object? value) => config.TryGetValue(key, out value);

        public void Save() => config.SaveConfig();

        public void Load() => config.LoadConfig();
    }
}
