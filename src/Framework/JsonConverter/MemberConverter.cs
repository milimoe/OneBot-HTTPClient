using System.Text.Json;
using Milimoe.FunGame.Core.Library.Common.Architecture;
using Milimoe.OneBot.Model.Other;

namespace Milimoe.OneBot.Framework.JsonConverter
{
    public class MemberConverter : BaseEntityConverter<Member>
    {
        public override Member NewInstance()
        {
            return new();
        }

        public override void ReadPropertyName(ref Utf8JsonReader reader, string propertyName, JsonSerializerOptions options, ref Member result, Dictionary<string, object> convertingContext)
        {
            switch (propertyName)
            {
                case "group_id":
                    result.group_id = reader.GetInt64();
                    break;
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
                case "join_time":
                    result.join_time = reader.GetInt32();
                    break;
                case "last_sent_time":
                    result.last_sent_time = reader.GetInt32();
                    break;
                case "level":
                    result.level = reader.GetString() ?? "";
                    break;
                case "role":
                    result.role = reader.GetString() ?? "";
                    break;
                case "unfriendly":
                    result.unfriendly = reader.GetBoolean();
                    break;
                case "title":
                    result.title = reader.GetString() ?? "";
                    break;
                case "title_expire_time":
                    result.title_expire_time = reader.GetInt32();
                    break;
                case "card_changeable":
                    result.card_changeable = reader.GetBoolean();
                    break;
            }
        }

        public override void Write(Utf8JsonWriter writer, Member value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WriteNumber("group_id", value.group_id);
            writer.WriteNumber("user_id", value.user_id);
            writer.WriteString("nickname", value.nickname);
            writer.WriteString("card", value.card);
            writer.WriteString("sex", value.sex);
            writer.WriteNumber("age", value.age);
            writer.WriteString("area", value.area);
            writer.WriteNumber("join_time", value.join_time);
            writer.WriteNumber("last_sent_time", value.last_sent_time);
            writer.WriteString("level", value.level);
            writer.WriteString("role", value.role);
            writer.WriteBoolean("unfriendly", value.unfriendly);
            writer.WriteString("title", value.title);
            writer.WriteNumber("title_expire_time", value.title_expire_time);
            writer.WriteBoolean("card_changeable", value.card_changeable);
            writer.WriteEndObject();
        }
    }
}