namespace System;

partial struct Optional<T>
{
    // TODO: Add the tests and open the methods/operators

    internal static bool Equals(Optional<T> left, T right)
        =>
        left.Contains(right);

    //public static bool operator ==(Optional<T> left, T right)
    //    =>
    //    left.Contains(right);

    //public static bool operator !=(Optional<T> left, T right)
    //    =>
    //    left.Contains(right) is not true;

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
