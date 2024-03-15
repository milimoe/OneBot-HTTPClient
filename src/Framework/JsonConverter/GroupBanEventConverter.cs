using System.Text.Json;
using Milimoe.FunGame.Core.Library.Common.Architecture;
using Milimoe.OneBot.Model.Event;

namespace Milimoe.OneBot.Framework.JsonConverter
{
    public class GroupBanEventConverter : BaseEntityConverter<GroupBanEvent>
    {
        public override void ReadPropertyName(ref Utf8JsonReader reader, string propertyName, JsonSerializerOptions options, ref GroupBanEvent? result)
        {
            result ??= new();
            switch (propertyName)
            {
                case "time":
                    result.time = reader.GetInt64();
                    break;
                case "self_id":
                    result.self_id = reader.GetInt64();
                    break;
                case "post_type":
                    result.post_type = reader.GetString() ?? "";
                    break;
                case "notice_type":
                    result.notice_type = reader.GetString() ?? "";
                    break;
                case "sub_type":
                    result.sub_type = reader.GetString() ?? "";
                    break;
                case "group_id":
                    result.group_id = reader.GetInt64();
                    break;
                case "operator_id":
                    result.operator_id = reader.GetInt64();
                    break;
                case "user_id":
                    result.user_id = reader.GetInt64();
                    break;
                case "duration":
                    result.duration = reader.GetInt32();
                    break;
            }
        }

        public override void Write(Utf8JsonWriter writer, GroupBanEvent value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WriteNumber("time", value.time);
            writer.WriteNumber("self_id", value.self_id);
            writer.WriteString("post_type", value.post_type);
            writer.WriteString("notice_type", value.notice_type);
            writer.WriteString("sub_type", value.sub_type);
            writer.WriteNumber("group_id", value.group_id);
            writer.WriteNumber("operator_id", value.operator_id);
            writer.WriteNumber("user_id", value.user_id);
            writer.WriteNumber("duration", value.duration);
            writer.WriteEndObject();
        }
    }
}
