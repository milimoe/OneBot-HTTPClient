using System.Text.Json.Serialization;
using Milimoe.OneBot.Framework.Interface;

namespace Milimoe.OneBot.Model.Content
{
    public class SetGroupKickContent(long group_id, long user_id, bool reject_add_request) : IContent
    {
        public long group_id { get; set; } = group_id;
        public long user_id { get; set; } = user_id;
        public bool reject_add_request { get; set; } = reject_add_request;

        [JsonIgnore]
        public string detail => $"将{user_id}从群聊{group_id}中踢出" + (reject_add_request ? "并且不再允许其申请加群" : "");
    }
}
