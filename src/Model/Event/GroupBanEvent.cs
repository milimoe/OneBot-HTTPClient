using System.Text.Json.Serialization;
using Milimoe.OneBot.Framework.Base;

namespace Milimoe.OneBot.Model.Event
{
    [method: JsonConstructor]
    public class GroupBanEvent(long time = 0, long self_id = 0, string post_type = "", string notice_type = "", string sub_type = "", long group_id = 0, long operator_id = 0, long user_id = 0, long duration = 0) : BaseGroupEvent(group_id)
    {
        public long time { get; set; } = time;
        public long self_id { get; set; } = self_id;
        public string post_type { get; set; } = post_type;
        public string notice_type { get; set; } = notice_type;
        public string sub_type { get; set; } = sub_type;
        public long operator_id { get; set; } = operator_id;
        public long user_id { get; set; } = user_id;
        public long duration { get; set; } = duration;

        [JsonIgnore]
        public string detail => $"{user_id}在群聊{group_id}中被{operator_id}" + (duration == 0 ? "解禁" : "禁言" + duration + "秒");
    }
}
