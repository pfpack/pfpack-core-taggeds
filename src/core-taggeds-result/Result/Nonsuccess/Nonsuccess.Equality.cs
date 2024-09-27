namespace System;

partial class Nonsuccess
{
    public static bool Equals<TFailure>(Nonsuccess<TFailure> left, Nonsuccess<TFailure> right)
        where TFailure : struct
        =>
        left.Equals(right);
}
