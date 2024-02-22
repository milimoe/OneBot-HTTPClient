using System.Text.Json.Serialization;
using Milimoe.OneBot.Framework.Interface;

namespace Milimoe.OneBot.Model.Content
{
    public class GroupMessageContent : IContent
    {
        public long group_id { get; set; }
        public List<IMessage> message { get; } = [];
        public bool auto_escape { get; set; } = false;

        public GroupMessageContent(long group_id)
        {
            this.group_id = group_id;
        }

        [JsonConstructor]
        public GroupMessageContent(long group_id, List<IMessage> message, bool auto_escape)
        {
            this.group_id = group_id;
            this.message = message;
            this.auto_escape = auto_escape;
        }
    }
}
