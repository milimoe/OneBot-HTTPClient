using System.Text.Json.Serialization;
using Milimoe.OneBot.Framework.Interface;
using Milimoe.OneBot.Model.Data;

namespace Milimoe.OneBot.Model.Message
{
    public class TextMessage : IMessage
    {
        public string type { get; set; } = "text";
        public IData data { get; set; }

        public TextMessage(string text)
        {
            data = new TextData(text);
        }

        [JsonConstructor]
        public TextMessage(string type, TextData data)
        {
            this.type = type;
            this.data = data;
        }
    }
}
