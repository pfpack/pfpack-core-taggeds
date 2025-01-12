using System.Collections.Generic;

namespace System;

partial class Optional
{
    // TODO: Add the tests and open the methods

    internal static int Compare<T>(Optional<T> left, Optional<T> right)
        where T : IComparable<T>
        =>
        left.InternalCompareTo(right, Comparer<T>.Default);

    internal static int Compare<T>(Optional<T> left, T right)
        where T : IComparable<T>
        =>
        left.InternalCompareTo(right, Comparer<T>.Default);

    internal static int Compare<T>(T left, Optional<T> right)
        where T : IComparable<T>
        =>
        right.InternalCompareTo(left, Comparer<T>.Default);
}
