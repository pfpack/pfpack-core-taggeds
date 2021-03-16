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
            .Filter(InternalCreateFilterNotNullOrThrowPredicate_Common<T>(exceptionFactory))
            .Map(InternalMapToNonNullable);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Optional<T> InternalFilterNotNullOrThrow<T>(this Optional<T?> optional, Func<Exception> exceptionFactory)
            where T : struct
            =>
            optional
            .Filter(InternalCreateFilterNotNullOrThrowPredicate_Struct<T>(exceptionFactory))
            .Map(InternalMapToNonNullable);
    }
}
