using Milimoe.OneBot.Framework;
using Milimoe.OneBot.Model.Content;
using Milimoe.OneBot.Model.Message;

namespace Milimoe.OneBot.Model.Other
{
    public class Group
    {
        public long group_id { get; set; } = 0;
        public string group_name { get; set; } = "";
        public int member_count { get; set; } = 0;
        public int max_member_count { get; set; } = 0;

        public async Task<HttpResponseMessage> SendMessage(string text, int delay = 0)
        {
            GroupMessageContent content = new(group_id);
            content.message.Add(new TextMessage(text));
            if (delay > 0)
            {
                await Task.Delay(delay);
            }
            return await HTTPPost.Post(SupportedAPI.send_group_msg, content);
        }

        public async Task<HttpResponseMessage> SendMessage(GroupMessageContent content, int delay = 0)
        {
            if (delay > 0)
            {
                await Task.Delay(delay);
            }
            return await HTTPPost.Post(SupportedAPI.send_group_msg, content);
        }
    }
}
