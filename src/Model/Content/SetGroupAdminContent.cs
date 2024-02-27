using System.Text.Json.Serialization;
using Milimoe.OneBot.Framework.Interface;

namespace Milimoe.OneBot.Model.Content
{
    public class SetGroupAdminContent(long group_id, long user_id, bool enable) : IContent
    {
        public long group_id { get; set; } = group_id;
        public long user_id { get; set; } = user_id;
        public bool enable { get; set; } = enable;

        [JsonIgnore]
        public string detail => enable ? $"设置{user_id}为群聊{group_id}的管理员" : $"取消{user_id}在群聊{group_id}的管理员权限";
    }
}
