using Milimoe.OneBot.Framework.Interface;

namespace Milimoe.OneBot.Model.Data
{
    public class IgnoreData(int ignore = 0) : IData
    {
        public int ignore { get; set; } = ignore;

        public override string ToString() => ignore.ToString();
    }
}
