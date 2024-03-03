namespace Milimoe.OneBot.Model.Content
{
    public class GetGroupInfoContent(long group_id, bool no_cache)
    {
        public long group_id { get; set; } = group_id;
        public bool no_cache { get; set; } = no_cache;
    }
}
