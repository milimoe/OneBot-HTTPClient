using System.Text.Json.Serialization;
using Milimoe.OneBot.Framework.Interface;

namespace Milimoe.OneBot.Model.Content
{
    public class FriendMessageContent : IContent
    {
        public long user_id { get; set; }
        public List<IMessage> message { get; } = [];

        [JsonIgnore]
        public string detail => string.Join(" ", message.Select(m => m.data.ToString()?.Trim() ?? "")).Trim();

        public FriendMessageContent(long user_id)
        {
            this.user_id = user_id;
        }

        [JsonConstructor]
        public FriendMessageContent(long user_id, List<IMessage> message)
        {
            this.user_id = user_id;
            this.message = message;
        }
    }
}
