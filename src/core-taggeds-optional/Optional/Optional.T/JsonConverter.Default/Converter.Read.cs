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

            //JsonSerializer.Deserialize(ref reader, )

            var isPresentPropertyName = InnerGetPropertyName(options, nameof(IsPresent));
            var isPresent = false;

            var valuePropertyName = InnerGetPropertyName(options, ValuePropertyName);
            var isValueFound = false;
            var value = default(T?);

            while (InnerReadNextToken(ref reader) is not JsonTokenType.EndObject)
            {
                if (reader.TokenType is JsonTokenType.StartArray)
                {
                    InnerReadUntil(ref reader, JsonTokenType.EndArray);
                    continue;
                }

                if (reader.TokenType is JsonTokenType.StartObject)
                {
                    InnerReadUntil(ref reader, JsonTokenType.EndObject);
                    continue;
                }

                if (reader.TokenType is not JsonTokenType.PropertyName)
                {
                    continue;
                }

                var propertyName = reader.GetString();
                if (isPresent is false && string.Equals(isPresentPropertyName, propertyName, StringComparison.InvariantCulture))
                {
                    isPresent = InnerReadNextBoolean(ref reader, isPresentPropertyName);
                    if (isPresent is false || isValueFound)
                    {
                        InnerReadUntil(ref reader, JsonTokenType.EndObject);
                        break;
                    }
                    continue;
                }

                if (isValueFound is false && string.Equals(valuePropertyName, propertyName, StringComparison.InvariantCulture))
                {
                    _ = InnerReadNextToken(ref reader);

                    value = valueConverter.Read(ref reader, InnerValueType.Value, options);
                    isValueFound = true;

                    if (isPresent)
                    {
                        InnerReadUntil(ref reader, JsonTokenType.EndObject);
                        break;
                    }
                    continue;
                }
            }

            if (isPresent is false)
            {
                return default;
            }

            return new(value!);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool InnerReadNextBoolean(ref Utf8JsonReader reader, string propertyName)
        {
            var nextToken = InnerReadNextToken(ref reader);
            if (nextToken is JsonTokenType.True)
            {
                return true;
            }

            if (nextToken is JsonTokenType.False)
            {
                return false;
            }

            throw InnerJsonExceptionFactory.JsonUnexpectedToken(nextToken, propertyName);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void InnerReadUntil(ref Utf8JsonReader reader, JsonTokenType expectedTokenType)
        {
            while (reader.Read())
            {
                if (reader.TokenType == expectedTokenType)
                {
                    return;
                }

                if (reader.TokenType is JsonTokenType.StartArray)
                {
                    InnerReadUntil(ref reader, JsonTokenType.EndArray);
                    continue;
                }

                if (reader.TokenType is JsonTokenType.StartObject)
                {
                    InnerReadUntil(ref reader, JsonTokenType.EndObject);
                    continue;
                }
            }

            throw InnerJsonExceptionFactory.JsonReadCompletedNoExpectedObject(expectedTokenType);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static JsonTokenType InnerReadNextToken(ref Utf8JsonReader reader)
            =>
            reader.Read() ? reader.TokenType : throw InnerJsonExceptionFactory.JsonReadCompletedNoEndObject();
    }
}