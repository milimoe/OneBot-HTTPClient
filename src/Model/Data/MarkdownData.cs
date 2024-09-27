using Milimoe.OneBot.Framework.Interface;

namespace Milimoe.OneBot.Model.Data
{
    public class MarkdownData(string data) : IData
    {
        public string data { get; set; } = data;

        public override string ToString() => data != "" ? $"[Markdown: {(data.Length > 80 ? data[..80] : data)}]" : "";
    }
}
