#nullable enable

using System.Runtime.CompilerServices;

namespace System
{
    partial class FilterNotNullOptionalExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Func<T, bool> CreateFilterNotNullOrThrowPredicate<T>()
            =>
            value => value is not null
                ? true
                : throw CreateExpectedNotNullOrAbsentException();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Func<T, bool> CreateFilterNotNullOrThrowPredicate<T>(Func<Exception> exceptionFactory)
            =>
            value => value is not null
                ? true
                : throw exceptionFactory.Invoke();
    }
}
