using System.Text.Json;
using System.Text.Json.Serialization;
using Milimoe.OneBot.Framework.Interface;
using Milimoe.OneBot.Model.Message;

namespace Milimoe.OneBot.Framework.JsonConverter
{
    public class IMessageConverter : JsonConverter<IMessage>
    {
        public override IMessage Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            using (JsonDocument doc = JsonDocument.ParseValue(ref reader))
            {
                JsonElement root = doc.RootElement;
                if (root.TryGetProperty("type", out JsonElement type_element))
                {
                    string type = type_element.GetString() ?? "";
                    if (type.Trim() != "")
                    {
                        return type switch
                        {
                            "at" => JsonSerializer.Deserialize<AtMessage>(root.GetRawText(), options) ?? new("", ""),
                            "image" => JsonSerializer.Deserialize<ImageMessage>(root.GetRawText(), options) ?? new(""),
                            "record" => JsonSerializer.Deserialize<RecordMessage>(root.GetRawText(), options) ?? new(""),
                            "reply" => JsonSerializer.Deserialize<ReplyMessage>(root.GetRawText(), options) ?? new(""),
                            _ => JsonSerializer.Deserialize<TextMessage>(root.GetRawText(), options) ?? new(""),
                        };
                    }
                }
            }
            return new TextMessage("");
        }

        public override void Write(Utf8JsonWriter writer, IMessage value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();

            if (value is AtMessage at)
            {
                writer.WritePropertyName("type");
                writer.WriteStringValue("at");

                writer.WritePropertyName("data");
                writer.WriteStartObject();
                writer.WritePropertyName("qq");
                writer.WriteStringValue(at.data.qq);
                writer.WriteEndObject();
            }
            else if (value is ImageMessage image)
            {
                writer.WritePropertyName("type");
                writer.WriteStringValue("image");

                writer.WritePropertyName("data");
                writer.WriteStartObject();
                writer.WritePropertyName("file");
                writer.WriteStringValue(image.data.file);
                writer.WritePropertyName("url");
                writer.WriteStringValue(image.data.url);
                writer.WriteEndObject();
            }
            else if (value is RecordMessage record)
            {
                writer.WritePropertyName("type");
                writer.WriteStringValue("record");

                writer.WritePropertyName("data");
                writer.WriteStartObject();
                writer.WritePropertyName("file");
                writer.WriteStringValue(record.data.file);
                writer.WritePropertyName("url");
                writer.WriteStringValue(record.data.url);
                writer.WriteEndObject();
            }
            else if (value is ReplyMessage reply)
            {
                writer.WritePropertyName("type");
                writer.WriteStringValue("reply");

                writer.WritePropertyName("data");
                writer.WriteStartObject();
                writer.WritePropertyName("id");
                writer.WriteStringValue(reply.data.id);
                writer.WriteEndObject();
            }
            else
            {
                writer.WritePropertyName("type");
                writer.WriteStringValue("text");

                writer.WritePropertyName("data");
                writer.WriteStartObject();
                writer.WritePropertyName("text");
                writer.WriteStringValue(value.data.ToString());
                writer.WriteEndObject();
            }

            writer.WriteEndObject();
        }
    }
}
