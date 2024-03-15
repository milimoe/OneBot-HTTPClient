using System.Text.Json.Serialization;
using Milimoe.OneBot.Framework.Base;
using Milimoe.OneBot.Model.Data;

namespace Milimoe.OneBot.Model.Message
{
    public class ReplyMessage : BaseMessage
    {
        public override string type { get; } = "Reply";
        public new ReplyData data { get; set; }

        public ReplyMessage(string id)
        {
            data = new ReplyData(id);
            base.data = data;
        }

        [JsonConstructor]
        public ReplyMessage(string type, ReplyData data)
        {
            this.type = type;
            this.data = data;
            base.data = data;
        }
    }
}
