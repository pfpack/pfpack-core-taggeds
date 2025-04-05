using System.Text.Json;

namespace System;

partial struct Optional<T>
{
    partial class DefaultJsonConverter
    {
        public override void Write(Utf8JsonWriter writer, Optional<T> value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName(InnerGetPropertyName(options, nameof(IsPresent)));

            if (value.hasValue is false)
            {
                writer.WriteBooleanValue(false);
            }
            else
            {
                writer.WriteBooleanValue(true);

                writer.WritePropertyName(InnerGetPropertyName(options, ValuePropertyName));
                valueConverter.Write(writer, value.value, options);
            }

            writer.WriteEndObject();
        }
    }
}