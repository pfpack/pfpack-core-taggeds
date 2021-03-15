#nullable enable

using System.Runtime.CompilerServices;

namespace System
{
    partial class FilterNotNullOptionalExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Optional<T> InternalFilterNotNullOrThrow<T>(
            this Optional<T> optional)
            =>
            optional
            .Filter(InternalCreateFilterNotNullOrThrowPredicate<T>(CreateExpectedNotNullOrAbsentException));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Optional<T> InternalFilterNotNullOrThrow<T>(
            this Optional<T> optional,
            Func<Exception> exceptionFactory)
            =>
            optional
            .Filter(InternalCreateFilterNotNullOrThrowPredicate<T>(exceptionFactory));
    }
}
