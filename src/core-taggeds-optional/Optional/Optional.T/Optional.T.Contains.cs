using System.Collections.Generic;

namespace System;

partial struct Optional<T>
{
    // TODO: Add the tests and open the methods

    internal bool Contains(T value)
        =>
        InnerContains(value, EqualityComparer<T>.Default);

    internal bool Contains(T value, IEqualityComparer<T>? comparer)
        =>
        InnerContains(value, comparer ?? EqualityComparer<T>.Default);
}
