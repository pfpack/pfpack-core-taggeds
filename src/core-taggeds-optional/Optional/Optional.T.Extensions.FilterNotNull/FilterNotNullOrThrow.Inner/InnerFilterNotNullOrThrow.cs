using System.Runtime.CompilerServices;

namespace System;

partial class FilterNotNullOptionalExtensions
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static Optional<T> InnerFilterNotNullOrThrow<T>(this Optional<T?> optional, Func<Exception> exceptionFactory)
        =>
        optional
        .OnPresent(value => value is not null ? default : throw exceptionFactory.Invoke())
        .Map(InnerToNonNullable);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static Optional<T> InnerFilterNotNullOrThrow<T>(this Optional<T?> optional, Func<Exception> exceptionFactory)
        where T : struct
        =>
        optional
        .OnPresent(value => value is not null ? default : throw exceptionFactory.Invoke())
        .Map(InnerToNonNullable);
}
