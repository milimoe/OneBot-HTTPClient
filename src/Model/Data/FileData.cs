﻿using Milimoe.OneBot.Framework.Interface;

namespace Milimoe.OneBot.Model.Data
{
    public class FileData(string file) : IData
    {
        public string file { get; set; } = file;
        public string type { get; set; } = "";
        public string url { get; set; } = "";
        public int cache { get; set; } = 1;
        public int proxy { get; set; } = 1;
        public long timeout { get; set; } = 0;

        public override string ToString() => file;
    }
}