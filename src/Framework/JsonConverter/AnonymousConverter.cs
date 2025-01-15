using System.Text.Json;
using Milimoe.FunGame.Core.Library.Common.Architecture;
using Milimoe.OneBot.Model.Other;

namespace Milimoe.OneBot.Framework.JsonConverter
{
    public class AnonymousConverter : BaseEntityConverter<Anonymous>
    {
        public override Anonymous NewInstance()
        {
            return new();
        }

        public override void ReadPropertyName(ref Utf8JsonReader reader, string propertyName, JsonSerializerOptions options, ref Anonymous result, Dictionary<string, object> convertingContext)
        {
            switch (propertyName)
            {
                case "id":
                    result.id = reader.GetInt64();
                    break;
                case "name":
                    result.name = reader.GetString() ?? "";
                    break;
                case "flag":
                    result.flag = reader.GetString() ?? "";
                    break;
            }
        }

        public override void Write(Utf8JsonWriter writer, Anonymous value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WriteNumber("id", value.id);
            writer.WriteString("name", value.name);
            writer.WriteString("flag", value.flag);
            writer.WriteEndObject();
        }
    }
}