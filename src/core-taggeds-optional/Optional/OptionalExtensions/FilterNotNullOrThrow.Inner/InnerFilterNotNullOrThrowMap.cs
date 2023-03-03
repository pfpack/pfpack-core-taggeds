using System.Runtime.CompilerServices;

namespace System;

partial class OptionalExtensions
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static Optional<T> InnerFilterNotNullOrThrowMap<T>(T? value, Func<Exception> exceptionFactory)
        =>
        value is not null
            ? new(value)
            : throw exceptionFactory.Invoke();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static Optional<T> InnerFilterNotNullOrThrowMap<T>(T? value, Func<Exception> exceptionFactory)
        where T : struct
        =>
        value is not null
            ? new(value.GetValueOrDefault())
            : throw exceptionFactory.Invoke();
}
