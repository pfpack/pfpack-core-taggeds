#nullable enable

namespace System
{
    partial class Present
    {
        public static bool Equals<T>(Present<T> left, Present<T> right)
            =>
            left.Equals(right);
    }
}
