using System.Text.Json;
using Milimoe.FunGame.Core.Library.Common.Architecture;
using Milimoe.OneBot.Framework.Interface;
using Milimoe.OneBot.Model.Event;
using Milimoe.OneBot.Model.Message;
using Milimoe.OneBot.Model.Other;

namespace Milimoe.OneBot.Framework.JsonConverter
{
    public class FriendMessageEventConverter : BaseEntityConverter<FriendMessageEvent>
    {
        public override FriendMessageEvent NewInstance()
        {
            return new();
        }

        public override void ReadPropertyName(ref Utf8JsonReader reader, string propertyName, JsonSerializerOptions options, ref FriendMessageEvent result, Dictionary<string, object> convertingContext)
        {
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
                case "message_type":
                    result.message_type = reader.GetString() ?? "";
                    result.post_sub_type = result.message_type;
                    break;
                case "sub_type":
                    result.sub_type = reader.GetString() ?? "";
                    break;
                case "message_id":
                    result.message_id = reader.GetInt64();
                    break;
                case "user_id":
                    result.user_id = reader.GetInt64();
                    break;
                case "message":
                    using (JsonDocument doc = JsonDocument.ParseValue(ref reader))
                    {
                        JsonElement je = doc.RootElement.Clone();
                        string json = je.GetRawText();
                        List<IMessage> messages = JsonSerializer.Deserialize<List<IMessage>>(json, options) ?? [new TextMessage("")];
                        result.message = messages;
                    }
                    break;
                case "raw_message":
                    result.raw_message = reader.GetString() ?? "";
                    break;
                case "font":
                    result.font = reader.GetInt32();
                    break;
                case "sender":
                    using (JsonDocument doc = JsonDocument.ParseValue(ref reader))
                    {
                        JsonElement je = doc.RootElement.Clone();
                        string json = je.GetRawText();
                        Sender sender = JsonSerializer.Deserialize<Sender>(json, options) ?? new();
                        result.sender = sender;
                    }
                    break;
            }
        }

        public override void Write(Utf8JsonWriter writer, FriendMessageEvent value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WriteNumber("time", value.time);
            writer.WriteNumber("self_id", value.self_id);
            writer.WriteString("post_type", value.post_type);
            writer.WriteString("sub_type", value.sub_type);
            writer.WriteNumber("message_id", value.message_id);
            writer.WriteNumber("user_id", value.user_id);
            writer.WritePropertyName("message");
            JsonSerializer.Serialize(writer, value.message, options);
            writer.WriteString("raw_message", value.raw_message);
            writer.WriteNumber("font", value.font);
            writer.WritePropertyName("sender");
            JsonSerializer.Serialize(writer, value.sender, options);
            writer.WriteEndObject();
        }
    }
}
