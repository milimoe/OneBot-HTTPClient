using System.Text.Json.Serialization;

namespace Milimoe.OneBot.Framework.Interface
{
    public interface IContent
    {
        [JsonIgnore]
        public string detail { get; }
    }
}
