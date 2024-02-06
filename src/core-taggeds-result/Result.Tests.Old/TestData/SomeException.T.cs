using System;

namespace PrimeFuncPack.Core.Tests;

internal sealed class SomeException<T> : Exception
{
    public SomeException(T value)
        =>
        Value = value;

    public T Value { get; }
}
