using System.Text.Json.Serialization;

namespace Milimoe.OneBot.Model.Other
{
    public class Sender
    {
        public long user_id { get; set; } = 0;
        public string nickname { get; set; } = "";
        public string card { get; set; } = "";
        public string sex { get; set; } = "";
        public int age { get; set; } = 0;
        public string area { get; set; } = "";
        public string level { get; set; } = "";
        public string role { get; set; } = "";
        public string title { get; set; } = "";

        public Sender()
        {

        }

        [JsonConstructor]
        public Sender(long user_id, string nickname, string card, string sex, int age, string area, string level, string role, string title)
        {
            this.user_id = user_id;
            this.nickname = nickname;
            this.card = card;
            this.sex = sex;
            this.age = age;
            this.area = area;
            this.level = level;
            this.role = role;
            this.title = title;
        }
    }
}
