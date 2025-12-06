using System.Text.Json;

namespace System;

partial struct Optional<T>
{
    partial class DefaultJsonConverter
    {
        public override void Write(Utf8JsonWriter writer, Optional<T> value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();

            if (value.hasValue)
            {
                writer.WritePropertyName(InnerGetPropertyName(options, PresentPropertyName));
                valueConverter.Write(writer, value.value, options);
            }
            else
            {
                writer.WritePropertyName(InnerGetPropertyName(options, AbsentPropertyName));

                writer.WriteStartObject();
                writer.WriteEndObject();
            }

            writer.WriteEndObject();
        }
    }
}