using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ProjectTirAuthorizationMicroservice.Infrastructure.JsonConverters
{
    public class DateOnlyJsonConverter : JsonConverter<DateOnly>
    {
        private const string Format = "dd-MM-yyyy";

        public override DateOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return DateOnly.Parse(reader.GetString()!);
        }

        public override DateOnly ReadAsPropertyName(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return DateOnly.Parse(reader.GetString()!);
        }

        public override void Write(Utf8JsonWriter writer, DateOnly value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString(Format, CultureInfo.InvariantCulture));
        }

        public override void WriteAsPropertyName(Utf8JsonWriter writer, DateOnly value, JsonSerializerOptions options)
        {
            var isoDate = value.ToString("O");
            writer.WritePropertyName(isoDate);
        }
    }
}
