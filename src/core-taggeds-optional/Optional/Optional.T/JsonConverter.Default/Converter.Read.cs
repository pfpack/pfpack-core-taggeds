using System.Runtime.CompilerServices;
using System.Text.Json;

namespace System;

partial struct Optional<T>
{
    partial class DefaultJsonConverter
    {
        public override Optional<T> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType is JsonTokenType.Null)
            {
                return default;
            }

            if (reader.TokenType is not JsonTokenType.StartObject)
            {
                throw InnerJsonExceptionFactory.JsonTokenNotStartObject();
            }

            var absentPropertyName = InnerGetPropertyName(options, AbsentPropertyName);
            var presentPropertyName = InnerGetPropertyName(options, PresentPropertyName);

            while (InnerReadNextToken(ref reader) is not JsonTokenType.EndObject)
            {
                if (reader.TokenType is JsonTokenType.StartObject or JsonTokenType.StartArray)
                {
                    reader.Skip();
                    continue;
                }

                if (reader.TokenType is not JsonTokenType.PropertyName)
                {
                    continue;
                }

                var propertyName = reader.GetString();
                if (string.Equals(absentPropertyName, propertyName, StringComparison.InvariantCulture))
                {
                    var nextToken = InnerReadNextToken(ref reader);
                    if (nextToken is JsonTokenType.StartObject or JsonTokenType.StartArray)
                    {
                        reader.Skip();
                    }

                    InnerReadUntilEndObject(ref reader);
                    return default;
                }

                if (string.Equals(presentPropertyName, propertyName, StringComparison.InvariantCulture))
                {
                    _ = InnerReadNextToken(ref reader);
                    var value = valueConverter.Read(ref reader, InnerValueType.Value, options);

                    InnerReadUntilEndObject(ref reader);
                    return new(value!);
                }
            }

            return default;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void InnerReadUntilEndObject(ref Utf8JsonReader reader)
        {
            while (reader.Read())
            {
                if (reader.TokenType is JsonTokenType.EndObject)
                {
                    return;
                }

                if (reader.TokenType is JsonTokenType.StartObject or JsonTokenType.StartArray)
                {
                    reader.Skip();
                    continue;
                }
            }

            throw InnerJsonExceptionFactory.JsonReadCompletedNoEndObject();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static JsonTokenType InnerReadNextToken(ref Utf8JsonReader reader)
            =>
            reader.Read() ? reader.TokenType : throw InnerJsonExceptionFactory.JsonReadCompletedNoEndObject();
    }
}