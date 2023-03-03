using System.Collections.Generic;

namespace System;

partial class OptionalExtensions
{
    // TODO: Add the tests and open the method
    internal static int CompareTo<T>(this Optional<T> optional, Optional<T> other) where T : IComparable<T>
        =>
        optional.InternalCompareTo(other, Comparer<T>.Default);

    // TODO: Add the tests and open the method
    internal static int CompareTo<T>(this Optional<T> optional, object? obj) where T : IComparable<T>
        =>
        obj switch
        {
            null => ComparisonResult.GreaterThan,

            Optional<T> otherOptional => optional.CompareTo(otherOptional),

            _ => throw new ArgumentException($"The object is not Optional<{typeof(T).Name}>.", nameof(obj))
        };
}
