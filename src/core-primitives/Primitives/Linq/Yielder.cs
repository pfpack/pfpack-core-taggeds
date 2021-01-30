#nullable enable

using System.Collections.Generic;

namespace System.Linq
{
    public static class Yielder
    {
        public static IEnumerable<T> YieldSingle<T>(T value)
        {
            yield return value;
        }

        public static IEnumerable<T> YieldEmpty<T>()
        {
            yield break;
        }
    }
}
