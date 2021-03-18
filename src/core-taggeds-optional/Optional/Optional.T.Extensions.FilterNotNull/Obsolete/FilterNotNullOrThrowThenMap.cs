#nullable enable

using System.Diagnostics.CodeAnalysis;

namespace System
{
    partial class FilterNotNullOptionalExtensions
    {
        [Obsolete(ObsoleteMessages.FilterNotNullOrThrowThenMap, error: true)]
        [DoesNotReturn]
        public static Optional<T> FilterNotNullOrThrowThenMap<T>(
            this Optional<T?> optional)
            where T : class
            =>
            throw new NotImplementedException(ObsoleteMessages.FilterNotNullOrThrowThenMap);

        [Obsolete(ObsoleteMessages.FilterNotNullOrThrowThenMap, error: true)]
        [DoesNotReturn]
        public static Optional<T> FilterNotNullOrThrowThenMap<T>(
            this Optional<T?> optional,
            Func<Exception> exceptionFactory)
            where T : class
            =>
            throw new NotImplementedException(ObsoleteMessages.FilterNotNullOrThrowThenMap);

        [Obsolete(ObsoleteMessages.FilterNotNullOrThrowThenMap, error: true)]
        [DoesNotReturn]
        public static Optional<T> FilterNotNullOrThrowThenMap<T>(
            this Optional<T?> optional)
            where T : struct
            =>
            throw new NotImplementedException(ObsoleteMessages.FilterNotNullOrThrowThenMap);

        [Obsolete(ObsoleteMessages.FilterNotNullOrThrowThenMap, error: true)]
        [DoesNotReturn]
        public static Optional<T> FilterNotNullOrThrowThenMap<T>(
            this Optional<T?> optional,
            Func<Exception> exceptionFactory)
            where T : struct
            =>
            throw new NotImplementedException(ObsoleteMessages.FilterNotNullOrThrowThenMap);
    }
}
