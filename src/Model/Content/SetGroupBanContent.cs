using System.Text.Json.Serialization;
using Milimoe.OneBot.Framework.Interface;

namespace Milimoe.OneBot.Model.Content
{
    public class SetGroupBanContent(long group_id, long user_id, long duration) : IContent
    {
        public long group_id { get; set; } = group_id;
        public long user_id { get; set; } = user_id;
        public long duration { get; set; } = duration;

        [JsonIgnore]
        public string detail => $"在群{group_id}中对{user_id}" + (duration > 0 ? $"禁言{duration}秒" : "解除禁言");
    }
}
