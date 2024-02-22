using Milimoe.OneBot.Framework.Interface;

namespace Milimoe.OneBot.Model.Data
{
    public class TextData(string text) : IData
    {
        public string text { get; set; } = text;
    }
}
