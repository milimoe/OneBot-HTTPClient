namespace Milimoe.OneBot.Model.QuickReply
{
    public class FriendMsgEventQuickReply(string reply = "", bool auto_escape = false)
    {
        public string reply { get; set; } = reply;
        public bool auto_escape { get; set; } = auto_escape;
    }
}
