#nullable enable

using System.Collections.Generic;

namespace System
{
    partial struct Optional<T>
    {
        private static IEnumerable<T> InnerYieldSingle(T value)
        {
            yield return value;
        }

        private static IEnumerable<T> InnerYieldEmpty()
        {
            yield break;
        }
    }
}
