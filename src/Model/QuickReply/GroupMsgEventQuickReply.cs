namespace Milimoe.OneBot.Model.QuickReply
{
    public class GroupMsgEventQuickReply(string reply = "", bool auto_escape = false, bool at_sender = false, bool delete = false, bool kick = false, bool ban = false, long ban_duration = 1800)
    {
        public string reply { get; set; } = reply;
        public bool auto_escape { get; set; } = auto_escape;
        public bool at_sender { get; set; } = at_sender;
        public bool delete { get; set; } = delete;
        public bool kick { get; set; } = kick;
        public bool ban { get; set; } = ban;
        public long ban_duration { get; set; } = ban_duration;
    }
}
