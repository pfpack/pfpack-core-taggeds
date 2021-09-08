#nullable enable

using System.Collections.Generic;

namespace System
{
    partial struct Optional<T>
    {
        // TODO: Consinder to open in v1.2
        private IEnumerable<T> Flatten()
            =>
            InnerFlattenOrYield();
    }
}
