namespace System;

partial class Optional
{
    public static bool Equals<T>(Optional<T> left, Optional<T> right)
        =>
        left.Equals(right);
}
