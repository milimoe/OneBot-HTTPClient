using System.Text.Json;
using System.Text.Json.Serialization;
using Milimoe.OneBot.Framework.JsonConverter;

namespace Milimoe.OneBot.Framework.Utility
{
    public class JsonTools
    {
        public readonly static JsonSerializerOptions options = new()
        {
            WriteIndented = true,
            ReferenceHandler = ReferenceHandler.IgnoreCycles,
            Converters = { new AnonymousConverter(), new GroupMessageEventConverter(), new SenderConverter(), new IMessageConverter() }
        };

        public static string GetString<T>(T obj)
        {
            return JsonSerializer.Serialize(obj, options);
        }

        public static T? GetObject<T>(string json)
        {
            return JsonSerializer.Deserialize<T>(json, options);
        }
    }
}
