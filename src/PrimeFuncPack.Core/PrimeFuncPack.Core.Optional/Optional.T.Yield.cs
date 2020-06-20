#nullable enable

using System.Collections.Generic;

namespace System
{
    partial struct Optional<T>
    {
        public IEnumerable<T> Yield()
        {
            if (box is object)
            {
                yield return box;
            }
        }
    }
}
