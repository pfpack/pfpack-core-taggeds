using System.Collections.Generic;

namespace System;

partial struct Optional<T>
{
    // TODO: Add the tests and open the method
    internal static IComparer<Optional<T>> CreateComparer(IComparer<T> comparer)
        =>
        new InternalComparer(comparer ?? throw new ArgumentNullException(nameof(comparer)));
}
