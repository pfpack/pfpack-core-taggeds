using System.Text.Json;
using System.Text.Json.Serialization;

namespace System;

partial struct Optional<T>
{
    internal sealed partial class OmitableJsonConverter : JsonConverter<Optional<T>>
    {
        private readonly JsonConverter<T> valueConverter;

        internal OmitableJsonConverter(JsonSerializerOptions options)
            =>
            valueConverter = (JsonConverter<T>)options.GetConverter(InnerValueType.Value);

        private static class InnerValueType
        {
            internal static readonly Type Value = typeof(T);
        }
    }
}