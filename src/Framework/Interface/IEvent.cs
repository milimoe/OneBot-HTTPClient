namespace Milimoe.OneBot.Framework.Interface
{
    public interface IEvent
    {
        public string original_msg { get; set; }
        public string post_type { get; set; }
        public string post_sub_type { get; set; }
    }
}
