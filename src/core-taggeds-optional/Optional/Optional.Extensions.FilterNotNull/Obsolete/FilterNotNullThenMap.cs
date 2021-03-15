#nullable enable

using System.Diagnostics.CodeAnalysis;

namespace System
{
    partial class FilterNotNullOptionalExtensions
    {
        [Obsolete(ObsoleteMessages.FilterNotNullThenMap, error: true)]
        [DoesNotReturn]
        public static Optional<T> FilterNotNullThenMap<T>(this Optional<T?> optional) where T : class
            =>
            throw new NotImplementedException(ObsoleteMessages.FilterNotNullThenMap);

        [Obsolete(ObsoleteMessages.FilterNotNullThenMap, error: true)]
        [DoesNotReturn]
        public static Optional<T> FilterNotNullThenMap<T>(this Optional<T?> optional) where T : struct
            =>
            throw new NotImplementedException(ObsoleteMessages.FilterNotNullThenMap);
    }
}
