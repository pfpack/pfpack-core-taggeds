using System.Collections.Generic;

namespace System;

partial class Optional
{
    // TODO: Add the tests and open the method
    internal static int Compare<T>(Optional<T> left, Optional<T> right)
        where T : IComparable<T>
        =>
        left.InternalCompareTo(right, Comparer<T>.Default);
}
