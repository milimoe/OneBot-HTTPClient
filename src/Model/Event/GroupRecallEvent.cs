using System.Text.Json.Serialization;
using Milimoe.OneBot.Framework.Base;

namespace Milimoe.OneBot.Model.Event
{
    [method: JsonConstructor]
    public class GroupRecallEvent(long time = 0, long self_id = 0, string post_type = "", string notice_type = "", long group_id = 0, long user_id = 0, long operator_id = 0, long message_id = 0) : BaseGroupEvent(group_id, post_type)
    {
        public long time { get; set; } = time;
        public long self_id { get; set; } = self_id;
        public string notice_type { get; set; } = notice_type;
        public long user_id { get; set; } = user_id;
        public long operator_id { get; set; } = operator_id;
        public long message_id { get; set; } = message_id;

        [JsonIgnore]
        public string detail => $"{user_id} 在群聊 {group_id} 中的消息（ID: {message_id}）被 {operator_id} 撤回";
    }
}
