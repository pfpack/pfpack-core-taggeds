using System.Collections.Generic;

namespace System;

partial class Optional
{
    // TODO: Add the tests and open the method
    internal static int Compare<T>(Optional<T> left, Optional<T> right)
        where T : IComparable<T>
        =>
        left.CompareTo(right);

    // TODO: Add the tests and open the method
    internal static IComparer<Optional<T>> CreateComparer<T>(IComparer<T> comparer)
        =>
        new Optional<T>.InternalComparer(comparer ?? throw new ArgumentNullException(nameof(comparer)));
}
