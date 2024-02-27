using Milimoe.OneBot.Framework.Interface;

namespace Milimoe.OneBot.Model.Data
{
    public class RecordData(string file) : IData
    {
        public string file { get; set; } = file;
        public int magic { get; set; } = 0;
        public string url { get; set; } = "";
        public int cache { get; set; } = 1;
        public int proxy { get; set; } = 1;
        public long timeout { get; set; } = 0;

        public override string ToString() => "录音";
    }
}
