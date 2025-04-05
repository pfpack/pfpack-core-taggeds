using System.Text.Json;

namespace System;

partial struct Optional<T>
{
    partial class OmitableJsonConverter
    {
        public override void Write(Utf8JsonWriter writer, Optional<T> value, JsonSerializerOptions options)
        {
            if (value.hasValue is false)
            {
                return;
            }

            valueConverter.Write(writer, value.value, options);
        }
    }
}