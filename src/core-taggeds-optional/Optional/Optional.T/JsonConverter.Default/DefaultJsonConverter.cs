using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace System;

partial struct Optional<T>
{
    internal sealed partial class DefaultJsonConverter : JsonConverter<Optional<T>>
    {
        private const string AbsentPropertyName = "Absent";

        private const string PresentPropertyName = "Present";

        private readonly JsonConverter<T> valueConverter;

        internal DefaultJsonConverter(JsonSerializerOptions options)
            =>
            valueConverter = (JsonConverter<T>)options.GetConverter(InnerValueType.Value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static string InnerGetPropertyName(JsonSerializerOptions options, string name)
        {
            if (options.PropertyNamingPolicy is null)
            {
                return name;
            }

            return options.PropertyNamingPolicy.ConvertName(name);
        }

        private static class InnerValueType
        {
            internal static readonly Type Value = typeof(T);
        }

        private static class InnerJsonExceptionFactory
        {
            internal static JsonException JsonTokenNotStartObject()
                =>
                new("The last processed JSON token is not the start of a JSON object.");

            internal static JsonException JsonReadCompletedNoEndObject()
                =>
                new("Reading the JSON completed, but the end of the JSON object was not found.");
        }
    }
}