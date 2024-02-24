namespace Milimoe.OneBot.Framework.Interface
{
    public interface IMessage
    {
        public string type { get; }
        public IData data { get; set; }
    }
}
