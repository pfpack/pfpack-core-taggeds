using System.Runtime.CompilerServices;

namespace System;

internal static class ComparisonResult
{
    internal const int LessThan = -1;

    internal const int EqualTo = default;

    internal const int GreaterThan = 1;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static int Normalize(int result) => result switch
    {
        < EqualTo => LessThan,
        > EqualTo => GreaterThan,
        _ => EqualTo
    };
}
