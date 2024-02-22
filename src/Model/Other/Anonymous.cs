using System.Text.Json.Serialization;

namespace Milimoe.OneBot.Model.Other
{
    public class Anonymous
    {
        public long id { get; set; } = 0;
        public string name { get; set; } = "";
        public string flag { get; set; } = "";

        public Anonymous()
        {

        }

        [JsonConstructor]
        public Anonymous(long id, string name, string flag)
        {
            this.id = id;
            this.name = name;
            this.flag = flag;
        }
    }
}
