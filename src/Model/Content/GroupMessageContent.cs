using System.Text.Json.Serialization;
using Milimoe.OneBot.Framework.Interface;

namespace Milimoe.OneBot.Model.Content
{
    public class GroupMessageContent : IContent
    {
        public long group_id { get; set; }
        public List<IMessage> message { get; } = [];

        [JsonIgnore]
        public string detail => string.Join(" ", message.Select(m => m.data.ToString()?.Trim() ?? ""));

        public GroupMessageContent(long group_id)
        {
            this.group_id = group_id;
        }

        [JsonConstructor]
        public GroupMessageContent(long group_id, List<IMessage> message)
        {
            this.group_id = group_id;
            this.message = message;
        }
    }
}
