using System.Runtime.CompilerServices;

namespace System;

partial class OptionalExtensions
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static Optional<T> InnerFilterNotNullMap<T>(T? value)
        =>
        value is not null
            ? new(value)
            : default;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static Optional<T> InnerFilterNotNullMap<T>(T? value)
        where T : struct
        =>
        value is not null
            ? new(value.GetValueOrDefault())
            : default;
}
