#nullable enable

using System.Collections.Generic;

namespace System.Linq
{
    public static partial class YieldExtensions
    {
        public static IEnumerable<T> YieldSingle<T>(this T value) => Yielder.YieldSingle(value);
    }
}
