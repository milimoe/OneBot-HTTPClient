using System.Text.Json.Serialization;
using Milimoe.OneBot.Framework.Interface;
using Milimoe.OneBot.Model.Data;

namespace Milimoe.OneBot.Model.Message
{
    public class AtMessage : IMessage
    {
        public string type { get; set; } = "at";
        public IData data { get; set; }

        public AtMessage(string qq)
        {
            data = new QQData(qq);
        }

        [JsonConstructor]
        public AtMessage(string type, QQData data)
        {
            this.type = type;
            this.data = data;
        }
    }
}
