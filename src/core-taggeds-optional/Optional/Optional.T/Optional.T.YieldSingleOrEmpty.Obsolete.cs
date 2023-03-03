using System.Collections.Generic;

namespace System;

partial struct Optional<T>
{
    // TODO: Remove the method in v3.0
    [Obsolete("This method is obsolete. Call YieldFlattened instead.", error: true)]
    public IEnumerable<T> YieldSingleOrEmpty()
        =>
        InnerYieldFlattened();
}
