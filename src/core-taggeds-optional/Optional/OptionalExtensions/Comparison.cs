using System.Collections.Generic;

namespace System;

partial class OptionalExtensions
{
    // TODO: Add the tests and open the methods

    internal static int CompareTo<T>(this Optional<T> optional, Optional<T> other)
        where T : IComparable<T>
        =>
        optional.InternalCompareTo(other, Comparer<T>.Default);

    internal static int CompareTo<T>(this Optional<T> optional, T other)
        where T : IComparable<T>
        =>
        optional.InternalCompareTo(other, Comparer<T>.Default);
}
