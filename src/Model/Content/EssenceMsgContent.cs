using System.Text.Json.Serialization;
using Milimoe.OneBot.Framework.Interface;

namespace Milimoe.OneBot.Model.Content
{
    public class EssenceMsgContent(long message_id) : IContent
    {
        public long message_id { get; set; } = message_id;

        [JsonIgnore]
        public string detail => "设置精华：" + message_id;
    }
}
