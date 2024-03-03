namespace Milimoe.OneBot.Model.Content
{
    public class GetGroupMemberInfoContent(long group_id, long user_id, bool no_cache)
    {
        public long group_id { get; set; } = group_id;
        public long user_id { get; set; } = user_id;
        public bool no_cache { get; set; } = no_cache;
    }
}
