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
            .OnPresent(InternalCreateNotNullOrThrowHandler_Common<T>(exceptionFactory))
            .Map(InternalMapToNonNullable);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Optional<T> InternalFilterNotNullOrThrow<T>(this Optional<T?> optional, Func<Exception> exceptionFactory)
            where T : struct
            =>
            optional
            .OnPresent(InternalCreateNotNullOrThrowHandler_Struct<T>(exceptionFactory))
            .Map(InternalMapToNonNullable);
    }
}
