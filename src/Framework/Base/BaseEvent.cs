using Milimoe.OneBot.Framework.Interface;

namespace Milimoe.OneBot.Framework.Base
{
    public class BaseEvent() : IEvent
    {
        public string original_msg { get; set; } = "";
    }
}
