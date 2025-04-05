using System;
using System.Text.Json.Serialization;

namespace PrimeFuncPack.Core.Tests;

public static partial class OptionalJsonSerializerTest
{
    public readonly record struct RefTypeValue
    {
        public Optional<string> Value { get; init; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Optional<int>[]? ArrayValues { get; init; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public StructTypeValue? InnerValue { get; init; }
    }

    public readonly record struct StructTypeValue
    {
        public Optional<int?> Value { get; init; }
    }
}