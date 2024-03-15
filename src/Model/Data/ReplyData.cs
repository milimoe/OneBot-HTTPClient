using Milimoe.OneBot.Framework.Interface;

namespace Milimoe.OneBot.Model.Data
{
    public class ReplyData(string id) : IData
    {
        public string id { get; set; } = id;

        public override string ToString() => $"[回复：{id}]";
    }
}
