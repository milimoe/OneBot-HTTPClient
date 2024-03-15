using System.Text.Json.Serialization;
using Milimoe.OneBot.Framework.Base;
using Milimoe.OneBot.Model.Data;

namespace Milimoe.OneBot.Model.Message
{
    public class ImageMessage : BaseMessage
    {
        public override string type { get; } = "image";
        public new ImageData data { get; set; }

        public ImageMessage(string file, string url = "")
        {
            data = new ImageData(file, url);
            base.data = data;
        }

        [JsonConstructor]
        public ImageMessage(string type, ImageData data)
        {
            this.type = type;
            this.data = data;
            base.data = data;
        }
    }
}
