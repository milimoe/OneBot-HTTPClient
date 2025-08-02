using System.Text.Json.Serialization;
using Milimoe.OneBot.Framework.Interface;

namespace Milimoe.OneBot.Model.Content
{
    public class DeleteMsgContent(long message_id) : IContent
    {
        public long message_id { get; set; } = message_id;

        [JsonIgnore]
        public string detail => "撤回消息：" + message_id;
    }
}
