﻿using System.Text.Json.Serialization;
using Milimoe.OneBot.Framework.Base;
using Milimoe.OneBot.Framework.Interface;
using Milimoe.OneBot.Model.Message;
using Milimoe.OneBot.Model.Other;

namespace Milimoe.OneBot.Model.Event
{
    public class GroupMessageEvent : BaseGroupEvent
    {
        public long time { get; set; } = 0;
        public long self_id { get; set; } = 0;
        public string message_type { get; set; } = "";
        public string sub_type { get; set; } = "";
        public long message_id { get; set; } = 0;
        public long user_id { get; set; } = 0;
        public int real_id { get; set; } = 0;
        public Anonymous anonymous { get; set; }
        public List<IMessage> message { get; set; }
        public string raw_message { get; set; } = "";
        public int font { get; set; } = 0;
        public Sender sender { get; set; }

        [JsonIgnore]
        public string detail => string.Join(" ", message.Select(m => m.data.ToString()?.Trim() ?? "")).Trim();

        public GroupMessageEvent(long group_id = 0, string post_type = "message") : base(group_id, post_type)
        {
            anonymous = new();
            sender = new();
            message = [new TextMessage("")];
        }

        [JsonConstructor]
        public GroupMessageEvent(long time, long self_id, string post_type, string message_type, string sub_type, int message_id, long group_id, long user_id, int real_id, Anonymous anonymous, List<IMessage> message, string raw_message, int font, Sender sender) : base(group_id, post_type)
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
