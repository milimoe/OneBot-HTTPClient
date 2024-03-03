using System.Text.Json;
using Milimoe.FunGame.Core.Library.Common.Architecture;
using Milimoe.OneBot.Model.Other;

namespace Milimoe.OneBot.Framework.JsonConverter
{
    public class GroupConverter : BaseEntityConverter<Group>
    {
        public override void ReadPropertyName(ref Utf8JsonReader reader, string propertyName, JsonSerializerOptions options, ref Group? result)
        {
            result ??= new();
            switch (propertyName)
            {
                case "group_id":
                    result.group_id = reader.GetInt64();
                    break;
                case "group_name":
                    result.group_name = reader.GetString() ?? "";
                    break;
                case "member_count":
                    result.member_count = reader.GetInt32();
                    break;
                case "max_member_count":
                    result.max_member_count = reader.GetInt32();
                    break;
            }
        }

        public override void Write(Utf8JsonWriter writer, Group value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WriteNumber("group_id", value.group_id);
            writer.WriteString("group_name", value.group_name);
            writer.WriteNumber("member_count", value.member_count);
            writer.WriteNumber("max_member_count", value.max_member_count);
            writer.WriteEndObject();
        }
    }
}