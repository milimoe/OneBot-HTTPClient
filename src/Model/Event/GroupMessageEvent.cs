using System.Text.Json.Serialization;
using Milimoe.OneBot.Framework.Base;
using Milimoe.OneBot.Framework.Interface;
using Milimoe.OneBot.Model.Message;
using Milimoe.OneBot.Model.Other;

namespace Milimoe.OneBot.Model.Event
{
    public class GroupMessageEvent : BaseEvent
    {
        public long time { get; set; } = 0;
        public long self_id { get; set; } = 0;
        public string post_type { get; set; } = "";
        public string message_type { get; set; } = "";
        public string sub_type { get; set; } = "";
        public long message_id { get; set; } = 0;
        public long group_id { get; set; } = 0;
        public long user_id { get; set; } = 0;
        public long real_id { get; set; } = 0;
        public Anonymous anonymous { get; set; }
        public IMessage message { get; set; }
        public string raw_message { get; set; } = "";
        public int font { get; set; } = 0;
        public Sender sender { get; set; }

        public GroupMessageEvent(string original_msg) : base(original_msg)
        {
            anonymous = new();
            sender = new();
            message = new AtMessage("");
        }

        [JsonConstructor]
        public GroupMessageEvent(string original_msg, long time, long self_id, string post_type, string message_type, string sub_type, int message_id, long group_id, long user_id, long real_id, Anonymous anonymous, IMessage message, string raw_message, int font, Sender sender) : base(original_msg)
        {
            this.time = time;
            this.self_id = self_id;
            this.post_type = post_type;
            this.message_type = message_type;
            this.sub_type = sub_type;
            this.message_id = message_id;
            this.group_id = group_id;
            this.user_id = user_id;
            this.real_id = real_id;
            this.anonymous = anonymous;
            this.message = message;
            this.raw_message = raw_message;
            this.font = font;
            this.sender = sender;
        }
    }
}
