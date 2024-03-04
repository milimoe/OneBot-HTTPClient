using Milimoe.OneBot.Framework.Interface;

namespace Milimoe.OneBot.Model.Content
{
    public class GetGroupInfoContent(long group_id, bool no_cache = false) : IContent
    {
        public long group_id { get; set; } = group_id;
        public bool no_cache { get; set; } = no_cache;

        public string detail => $"获取群聊{group_id}的信息, 是否不使用缓存：{no_cache}。";
    }
}
