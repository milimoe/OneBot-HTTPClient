using System.Text.Json.Serialization;
using Milimoe.OneBot.Framework.Base;
using Milimoe.OneBot.Model.Data;

namespace Milimoe.OneBot.Model.Message
{
    public class TextMessage : BaseMessage
    {
        public override string type { get; } = "text";
        public new TextData data { get; set; }

        public TextMessage(string text)
        {
            data = new TextData(text);
            base.data = data;
        }

        [JsonConstructor]
        public TextMessage(string type, TextData data)
        {
            this.type = type;
            this.data = data;
            base.data = data;
        }
    }
}
