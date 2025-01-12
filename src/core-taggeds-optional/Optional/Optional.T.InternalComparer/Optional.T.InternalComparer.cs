using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace System;

partial struct Optional<T>
{
    internal sealed class InternalComparer : IComparer<Optional<T>>
    {
        private readonly IComparer<T> comparer;

        internal InternalComparer(IComparer<T> comparer)
            =>
            this.comparer = comparer;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int Compare(Optional<T> x, Optional<T> y)
        {
            if (x.hasValue != y.hasValue)
            {
                return x.hasValue ? GreaterThan : LessThan;
            }

            if (x.hasValue)
            {
                return comparer.Compare(x.value, y.value) switch
                {
                    > EqualTo => GreaterThan,
                    < EqualTo => LessThan,
                    _ => EqualTo
                };
            }

            return EqualTo;
        }

        private const int GreaterThan = 1;
        private const int EqualTo = default;
        private const int LessThan = -1;
    }
}
