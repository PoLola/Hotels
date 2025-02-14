using System.Text.Json;
using System.Text.Json.Serialization;

namespace Hotels.Api.Converters
{
    public class JsonDateTimeConverter : JsonConverter<DateTime>
    {
        private readonly string _dateFormat;

        public JsonDateTimeConverter(string dateFormat)
        {
            _dateFormat = dateFormat;
        }

        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.String)
            {
                if (DateTime.TryParseExact(reader.GetString(), _dateFormat, null, System.Globalization.DateTimeStyles.None, out DateTime date))
                {
                    return date;
                }
            }
            throw new JsonException($"Unable to parse DateTime with the format: {_dateFormat}");
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString(_dateFormat));
        }
    }
}