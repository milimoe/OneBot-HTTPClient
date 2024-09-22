using System.Text.Json.Serialization;
using Milimoe.OneBot.Framework.Interface;

namespace Milimoe.OneBot.Model.Content
{
    public class DeleteEssenceMsgContent(int message_id) : IContent
    {
        public int message_id { get; set; } = message_id;

        [JsonIgnore]
        public string detail => "取消精华：" + message_id;
    }
}
