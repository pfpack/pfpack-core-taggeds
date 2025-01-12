using System.Collections.Generic;

namespace System;

partial struct Optional<T>
{
    internal sealed class InternalComparer : IComparer<Optional<T>>
    {
        private readonly IComparer<T> comparer;

        internal InternalComparer(IComparer<T> comparer)
            =>
            this.comparer = comparer;

        public int Compare(Optional<T> x, Optional<T> y)
            =>
            x.InternalCompareTo(y, comparer);
    }
}
