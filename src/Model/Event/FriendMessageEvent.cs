using System.Text.Json.Serialization;
using Milimoe.OneBot.Framework;
using Milimoe.OneBot.Framework.Base;
using Milimoe.OneBot.Framework.Interface;
using Milimoe.OneBot.Model.Content;
using Milimoe.OneBot.Model.Message;
using Milimoe.OneBot.Model.Other;

namespace Milimoe.OneBot.Model.Event
{
    public class FriendMessageEvent : BaseEvent
    {
        public long time { get; set; } = 0;
        public long self_id { get; set; } = 0;
        public string message_type { get; set; } = "";
        public string sub_type { get; set; } = "";
        public long message_id { get; set; } = 0;
        public long user_id { get; set; } = 0;
        public List<IMessage> message { get; set; }
        public string raw_message { get; set; } = "";
        public int font { get; set; } = 0;
        public Sender sender { get; set; }

        [JsonIgnore]
        public string detail => string.Join(" ", message.Select(m => m.data.ToString()?.Trim() ?? "")).Trim();

        public FriendMessageEvent(string post_type = "message") : base(post_type)
        {
            sender = new();
            message = [new TextMessage("")];
        }

        [JsonConstructor]
        public FriendMessageEvent(long time, long self_id, string post_type, string message_type, string sub_type, int message_id, long user_id, List<IMessage> message, string raw_message, int font, Sender sender) : base(post_type)
        {
            this.time = time;
            this.self_id = self_id;
            this.post_type = post_type;
            this.message_type = message_type;
            this.sub_type = sub_type;
            this.message_id = message_id;
            this.user_id = user_id;
            this.message = message;
            this.raw_message = raw_message;
            this.font = font;
            this.sender = sender;
        }

        public async Task<HttpResponseMessage> SendMessage(string text, int delay = 0)
        {
            FriendMessageContent content = new(user_id);
            content.message.Add(new TextMessage(text));
            if (delay > 0)
            {
                await Task.Delay(delay);
            }
            return await HTTPPost.Post(SupportedAPI.send_private_msg, content);
        }

        public async Task<HttpResponseMessage> SendMessage(FriendMessageContent content, int delay = 0)
        {
            if (delay > 0)
            {
                await Task.Delay(delay);
            }
            return await HTTPPost.Post(SupportedAPI.send_private_msg, content);
        }
    }
}
