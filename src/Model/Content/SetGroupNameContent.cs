using System.Text.Json.Serialization;
using Milimoe.OneBot.Framework.Interface;

namespace Milimoe.OneBot.Model.Content
{
    public class SetGroupNameContent(long group_id, string group_name) : IContent
    {
        public long group_id { get; set; } = group_id;
        public string group_name { get; set; } = group_name;

        [JsonIgnore]
        public string detail => $"设置群聊{group_id}的群名为{group_name}";
    }
}
