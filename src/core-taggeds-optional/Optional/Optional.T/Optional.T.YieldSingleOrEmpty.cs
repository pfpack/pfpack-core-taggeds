#nullable enable

using System.Collections.Generic;
using System.Linq;

namespace System
{
    partial struct Optional<T>
    {
        public IEnumerable<T> YieldSingleOrEmpty()
            =>
            InnerFold(
                Yielder<T>.YieldSingle,
                Yielder<T>.YieldEmpty);
    }
}
