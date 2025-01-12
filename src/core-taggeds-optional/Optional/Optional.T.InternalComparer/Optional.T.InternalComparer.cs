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
                return x.hasValue ? ComparisonResult.GreaterThan : ComparisonResult.LessThan;
            }

            if (x.hasValue)
            {
                return ComparisonResult.Normalize(comparer.Compare(x.value, y.value));
            }

            return ComparisonResult.EqualTo;
        }
    }
}
