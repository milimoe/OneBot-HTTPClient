using Milimoe.OneBot.Framework.Interface;

namespace Milimoe.OneBot.Model.Data
{
    public class PokeData(string type, string id, string name) : IData
    {
        public string type { get; set; } = type;
        public string id { get; set; } = id;
        public string name { get; set; } = name;

        public override string ToString() => "[戳一戳]";
    }
}
