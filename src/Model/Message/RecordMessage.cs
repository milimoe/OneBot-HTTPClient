using System.Text.Json.Serialization;
using Milimoe.OneBot.Framework.Interface;
using Milimoe.OneBot.Model.Data;

namespace Milimoe.OneBot.Model.Message
{
    public class RecordMessage : IMessage
    {
        public string type { get; set; } = "record";
        public IData data { get; set; }

        public RecordMessage(string file)
        {
            data = new FileData(file);
        }

        [JsonConstructor]
        public RecordMessage(string type, FileData data)
        {
            this.type = type;
            this.data = data;
        }
    }
}
