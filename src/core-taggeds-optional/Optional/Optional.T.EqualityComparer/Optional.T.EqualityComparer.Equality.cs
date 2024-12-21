using System.Runtime.CompilerServices;

namespace System;

partial struct Optional<T>
{
    partial class EqualityComparer
    {
        public bool Equals(Optional<T> x, Optional<T> y)
        {
            if (x.hasValue != y.hasValue)
            {
                return false;
            }

            if (x.hasValue)
            {
                return comparer.Equals(x.value, y.value);
            }

            return true;
        }

        public int GetHashCode(Optional<T> obj)
            =>
            obj.hasValue ? PresentHashCode(obj.value) : AbsentHashCode();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private int PresentHashCode(T value)
            =>
            value is not null
            ? HashCode.Combine(true, comparer.GetHashCode(value))
            : HashCode.Combine(true);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static int AbsentHashCode()
            =>
            HashCode.Combine(false);
    }
}
