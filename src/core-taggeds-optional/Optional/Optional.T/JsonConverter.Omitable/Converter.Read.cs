using System.Text.Json;

namespace System;

partial struct Optional<T>
{
    partial class OmitableJsonConverter
    {
        public override Optional<T> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            =>
            new(
                value: valueConverter.Read(ref reader, InnerValueType.Value, options)!);
    }
}