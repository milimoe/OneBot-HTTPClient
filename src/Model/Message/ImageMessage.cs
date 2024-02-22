using System.Text.Json.Serialization;
using Milimoe.OneBot.Framework.Interface;
using Milimoe.OneBot.Model.Data;

namespace Milimoe.OneBot.Model.Message
{
    public class ImageMessage : IMessage
    {
        public string type { get; set; } = "image";
        public IData data { get; set; }

        public ImageMessage(string file)
        {
            data = new FileData(file);
        }

        [JsonConstructor]
        public ImageMessage(string type, FileData data)
        {
            this.type = type;
            this.data = data;
        }
    }
}
