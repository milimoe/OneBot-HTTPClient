using Milimoe.OneBot.Model.Content;
using Milimoe.OneBot.Model.Message;

namespace Milimoe.OneBot.Framework.Base
{
    public class BaseGroupEvent(long group_id, string post_type) : BaseEvent(post_type)
    {
        public long group_id { get; set; } = group_id;

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
