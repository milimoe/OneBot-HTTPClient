using Milimoe.OneBot.Framework.Interface;

namespace Milimoe.OneBot.Model.Data
{
    public class AtData(string mention, string qq) : IData
    {
        public string mention { get; set; } = mention;
        public string qq { get; set; } = qq;

        public override string ToString() => $"@{qq}";
    }
}
