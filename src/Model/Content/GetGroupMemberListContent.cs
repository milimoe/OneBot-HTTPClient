using Milimoe.OneBot.Framework.Interface;

namespace Milimoe.OneBot.Model.Content
{
    public class GetGroupMemberListContent(long group_id) : IContent
    {
        public long group_id { get; set; } = group_id;

        public string detail => $"获取群聊{group_id}的群成员列表";
    }
}
