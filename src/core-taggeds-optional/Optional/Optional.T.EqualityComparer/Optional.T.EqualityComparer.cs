using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace System;

partial struct Optional<T>
{
    // TODO: Add the tests and open the class
    internal sealed class EqualityComparer : IEqualityComparer<Optional<T>>
    {
        private readonly IEqualityComparer<T> comparer;

        private EqualityComparer(IEqualityComparer<T> comparer)
            =>
            this.comparer = comparer;

        public static EqualityComparer Create(IEqualityComparer<T>? comparer)
            =>
            new(comparer ?? EqualityComparer<T>.Default);

        public static EqualityComparer Create()
            =>
            new(EqualityComparer<T>.Default);

        public static EqualityComparer Default
            =>
            InnerDefault.Value;

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
            obj.hasValue ? PresentHashCode(obj.value) : default;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private int PresentHashCode(T value)
            =>
            value is not null ? HashCode.Combine(comparer.GetHashCode(value)) : 1;

        private static class InnerDefault
        {
            internal static readonly EqualityComparer Value = Create();
        }
    }
}
