namespace System;

partial class Optional
{
    // TODO: Add the tests and open the methods

    internal static bool Equals<T>(Optional<T> left, T right)
        =>
        left.Contains(right);

    internal static bool Equals<T>(T left, Optional<T> right)
        =>
        right.Contains(left);
}
