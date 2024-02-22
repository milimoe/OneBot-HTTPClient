using Milimoe.OneBot.Framework.Interface;

namespace Milimoe.OneBot.Model.Data
{
    public class QQData(string qq) : IData
    {
        public string qq { get; set; } = qq;

        public override string ToString() => qq;
    }
}
