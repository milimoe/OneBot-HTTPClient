using System.Text.Json.Serialization;
using Milimoe.OneBot.Framework.Base;
using Milimoe.OneBot.Model.Data;

namespace Milimoe.OneBot.Model.Message
{
    public class AtMessage : BaseMessage
    {
        public override string type { get; } = "at";
        public new AtData data { get; set; }

        public AtMessage(string mention, string qq)
        {
            data = new AtData(mention, qq);
            base.data = data;
        }

        public AtMessage(long qq)
        {
            string qqstr = qq.ToString();
            data = new AtData(qqstr, qqstr);
            base.data = data;
        }

        [JsonConstructor]
        public AtMessage(string type, AtData data)
        {
            this.type = type;
            this.data = data;
            base.data = data;
        }
    }
}
