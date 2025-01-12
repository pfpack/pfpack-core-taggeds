using System.Collections.Generic;

namespace System;

partial struct Optional<T>
{
    private sealed class InnerComparer : IComparer<Optional<T>>
    {
        private readonly IComparer<T> comparer;

        internal InnerComparer(IComparer<T> comparer)
            =>
            this.comparer = comparer;

        public int Compare(Optional<T> x, Optional<T> y)
            =>
            x.InternalCompareTo(y, comparer);
    }
}
