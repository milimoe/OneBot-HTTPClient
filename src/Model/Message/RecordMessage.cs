using System.Text.Json.Serialization;
using Milimoe.OneBot.Framework.Base;
using Milimoe.OneBot.Model.Data;

namespace Milimoe.OneBot.Model.Message
{
    public class RecordMessage : BaseMessage
    {
        public override string type { get; } = "record";
        public new RecordData data { get; set; }

        public RecordMessage(string file)
        {
            data = new RecordData(file);
            base.data = data;
        }

        [JsonConstructor]
        public RecordMessage(string type, RecordData data)
        {
            this.type = type;
            this.data = data;
            base.data = data;
        }
    }
}
