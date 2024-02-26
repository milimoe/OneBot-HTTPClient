using System.Text.Json.Serialization;

namespace Milimoe.OneBot.Framework.Interface
{
    public interface IContent
    {
        public List<IMessage> message { get; }

        [JsonIgnore]
        public string detail { get; }
    }
}
