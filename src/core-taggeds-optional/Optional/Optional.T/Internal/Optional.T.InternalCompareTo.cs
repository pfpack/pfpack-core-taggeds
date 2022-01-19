using System.Runtime.CompilerServices;
using static System.FormattableString;

namespace System;

partial struct Optional<T>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal int InternalCompareTo(Optional<T> other)
        =>
        InnerCompareTo(other);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal int InternalCompareTo(object? obj, [CallerArgumentExpression("obj")] string? paramName = null) => obj switch
    {
        null => 1,

        Optional<T> other => InnerCompareTo(other),

        _ => throw new ArgumentException(Invariant($"The object is not Optional[{typeof(T)}]"), paramName)
    };
}
