using System.Runtime.CompilerServices;

namespace System;

internal static class ComparisonResult
{
    public const int LessThan = -1;

    public const int EqualTo = default;

    public const int GreaterThan = 1;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int Normalize(int result) => result switch
    {
        < EqualTo => LessThan,
        > EqualTo => GreaterThan,
        _ => EqualTo
    };
}
