using System.Runtime.CompilerServices;

namespace System;

partial class FilterNotNullOptionalExtensions
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static Optional<T> InnerFilterNotNull<T>(this Optional<T?> optional)
        =>
        optional
        .Filter(value => value is not null)
        .Map(value => value!);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static Optional<T> InnerFilterNotNull<T>(this Optional<T?> optional)
        where T : struct
        =>
        optional
        .Filter(value => value is not null)
        .Map(value => value.GetValueOrDefault());
}
