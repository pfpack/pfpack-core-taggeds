using System.Collections.Generic;

namespace System;

partial class OptionalExtensions
{
    // TODO: Add the tests and open the method
    internal static int CompareTo<T>(this Optional<T> optional, Optional<T> other) where T : IComparable<T>
        =>
        optional.InternalCompareTo(other, Comparer<T>.Default);
}
