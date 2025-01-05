using System.Collections.Generic;

namespace System;

partial struct Optional<T>
{
    internal sealed class InternalComparer(IComparer<T> comparer) : IComparer<Optional<T>>
    {
        public int Compare(Optional<T> x, Optional<T> y)
            =>
            x.InternalCompareTo(y, comparer);
    }
}
