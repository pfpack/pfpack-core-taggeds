using System.Collections.Generic;

namespace System;

partial struct Optional<T>
{
    public IEnumerable<T> Flatten()
        =>
        InnerFlattenOrYield();
}
