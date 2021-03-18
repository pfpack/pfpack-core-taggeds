#nullable enable

namespace System
{
    partial class Failure
    {
        public static bool Equals<TFailureCode>(
            Failure<TFailureCode> left, Failure<TFailureCode> right)
            where TFailureCode : struct
            =>
            left.Equals(right);
    }
}
