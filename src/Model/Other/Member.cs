namespace Milimoe.OneBot.Model.Other
{
    public class Member
    {
        public long group_id { get; set; } = 0;
        public long user_id { get; set; } = 0;
        public string nickname { get; set; } = "";
        public string card { get; set; } = "";
        public string sex { get; set; } = "";
        public int age { get; set; } = 0;
        public string area { get; set; } = "";
        public int join_time { get; set; } = 0;
        public int last_sent_time { get; set; } = 0;
        public string level { get; set; } = "";
        public string role { get; set; } = "";
        public bool unfriendly { get; set; } = false;
        public string title { get; set; } = "";
        public int title_expire_time { get; set; } = 0;
        public bool card_changeable { get; set; } = true;
    }
}
