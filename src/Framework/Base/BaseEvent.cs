using Milimoe.OneBot.Framework.Interface;

namespace Milimoe.OneBot.Framework.Base
{
    public class BaseEvent(string original_msg) : IEvent
    {
        public string original_msg { get; set; } = original_msg;
    }
}
