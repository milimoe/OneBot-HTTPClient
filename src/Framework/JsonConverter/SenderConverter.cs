using System.Text.Json;
using Milimoe.FunGame.Core.Library.Common.Architecture;
using Milimoe.OneBot.Model.Other;

namespace Milimoe.OneBot.Framework.JsonConverter
{
    public class SenderConverter : BaseEntityConverter<Sender>
    {
        public override Sender NewInstance()
        {
            return new();
        }

        public override void ReadPropertyName(ref Utf8JsonReader reader, string propertyName, JsonSerializerOptions options, ref Sender result)
        {
            switch (propertyName)
            {
                case "user_id":
                    result.user_id = reader.GetInt64();
                    break;
                case "nickname":
                    result.nickname = reader.GetString() ?? "";
                    break;
                case "card":
                    result.card = reader.GetString() ?? "";
                    break;
                case "sex":
                    result.sex = reader.GetString() ?? "";
                    break;
                case "age":
                    result.age = reader.GetInt32();
                    break;
                case "area":
                    result.area = reader.GetString() ?? "";
                    break;
                case "level":
                    result.level = reader.GetString() ?? "";
                    break;
                case "role":
                    result.role = reader.GetString() ?? "";
                    break;
                case "title":
                    result.title = reader.GetString() ?? "";
                    break;
            }
        }

        public override void Write(Utf8JsonWriter writer, Sender value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WriteNumber("user_id", value.user_id);
            writer.WriteString("nickname", value.nickname);
            writer.WriteString("card", value.card);
            writer.WriteString("sex", value.sex);
            writer.WriteNumber("age", value.age);
            writer.WriteString("area", value.area);
            writer.WriteString("level", value.level);
            writer.WriteString("role", value.role);
            writer.WriteString("title", value.title);
            writer.WriteEndObject();
        }
    }
}