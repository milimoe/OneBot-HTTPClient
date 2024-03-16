using Milimoe.OneBot.Framework.Interface;

namespace Milimoe.OneBot.Framework.Base
{
    public class BaseEvent(string post_type) : IEvent
    {
        public string original_msg { get; set; } = "";
        public string post_type { get; set; } = post_type;
        public string post_sub_type { get; set; } = "";

        public bool CheckThrow(long lesserthan, out long dice)
        {
            dice = new Random().NextInt64(100);
            return dice < lesserthan;
        }
    }
}
