using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace System;

partial struct Optional<T>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private IEnumerable<T> InnerFlattenOrYield()
        =>
        InnerFold(
            InnerYieldSingle,
            InnerYieldEmpty);

    private static IEnumerable<T> InnerYieldSingle(T value)
    {
        yield return value;
    }

    private static IEnumerable<T> InnerYieldEmpty()
    {
        yield break;
    }
}
