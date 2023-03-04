using System.Collections.Generic;

namespace System;

partial struct Optional<T>
{
    // TODO: Add the tests and open the class
    internal sealed class Comparer : IComparer<Optional<T>>
    {
        private readonly IComparer<T> comparer;

        private Comparer(IComparer<T> comparer)
            =>
            this.comparer = comparer;

        public static Comparer Create(IComparer<T> comparer)
            =>
            new(comparer ?? throw new ArgumentNullException(nameof(comparer)));

        public int Compare(Optional<T> x, Optional<T> y)
            =>
            x.InternalCompareTo(y, comparer);
    }
}
