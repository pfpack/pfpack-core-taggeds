using System.Text.Json.Serialization;

namespace System;

[JsonConverter(typeof(DefaultOptionalJsonConverterFactory))]
public readonly partial struct Optional<T> : IEquatable<Optional<T>>
{
    private readonly bool hasValue;

    private readonly T value;

    public bool IsPresent
        =>
        hasValue;

    public bool IsAbsent
        =>
        hasValue is not true;
}
