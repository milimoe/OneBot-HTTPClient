using System.Text.Json.Serialization;
using Milimoe.OneBot.Framework.Base;
using Milimoe.OneBot.Model.Data;

namespace Milimoe.OneBot.Model.Message
{
    public class MarkdownMessage : BaseMessage
    {
        public override string type { get; } = "markdown";
        public new MarkdownData data { get; set; }

        public MarkdownMessage(string md)
        {
            data = new MarkdownData(md);
            base.data = data;
        }

        [JsonConstructor]
        public MarkdownMessage(string type, MarkdownData data)
        {
            this.type = type;
            this.data = data;
            base.data = data;
        }
    }
}
