#nullable enable

using System.Runtime.CompilerServices;

namespace System
{
    partial class FilterNotNullOptionalExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Optional<T> InternalFilterNotNullOrThrow<T>(this Optional<T?> optional, Func<Exception> exceptionFactory)
            =>
            optional
            .OnPresent(value => value.InternalThrowOnNull(exceptionFactory))
            .Map(InternalMapToNonNullable);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Optional<T> InternalFilterNotNullOrThrow<T>(this Optional<T?> optional, Func<Exception> exceptionFactory)
            where T : struct
            =>
            optional
            .OnPresent(value => value.InternalThrowOnNull(exceptionFactory))
            .Map(InternalMapToNonNullable);
    }
}
