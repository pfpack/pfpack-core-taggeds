#nullable enable

using System.Collections.Generic;
using static System.Linq.Yielder;

namespace System
{
    partial struct Optional<T>
    {
        public IEnumerable<T> YieldSingleOrEmpty()
            =>
            Fold(YieldSingle, YieldEmpty<T>);
    }
}
