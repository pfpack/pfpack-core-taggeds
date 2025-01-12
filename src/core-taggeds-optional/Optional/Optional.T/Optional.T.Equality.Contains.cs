using System.Collections.Generic;

namespace System;

partial struct Optional<T>
{
    // TODO: Add the tests and open the methods/operators

    internal bool Contains(T value, IEqualityComparer<T>? comparer)
        =>
        InnerContains(value, comparer ?? EqualityComparer<T>.Default);

    internal bool Contains(T value)
        =>
        InnerContains(value, EqualityComparer<T>.Default);

    internal static bool Equals(Optional<T> left, T right, IEqualityComparer<T>? comparer)
        =>
        left.Contains(right, comparer);

    internal static bool Equals(Optional<T> left, T right)
        =>
        left.Contains(right);

    //public static bool operator ==(Optional<T> left, T right)
    //    =>
    //    left.Contains(right);

    //public static bool operator !=(Optional<T> left, T right)
    //    =>
    //    left.Contains(right) is not true;

    internal static bool Equals(T left, Optional<T> right, IEqualityComparer<T>? comparer)
        =>
        right.Contains(left, comparer);

    internal static bool Equals(T left, Optional<T> right)
        =>
        right.Contains(left);

    //public static bool operator ==(T left, Optional<T> right)
    //    =>
    //    right.Contains(left);

    //public static bool operator !=(T left, Optional<T> right)
    //    =>
    //    right.Contains(left) is not true;
}
