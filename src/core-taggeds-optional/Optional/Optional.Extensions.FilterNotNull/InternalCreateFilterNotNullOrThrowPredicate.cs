#nullable enable

using System.Runtime.CompilerServices;

namespace System
{
    partial class FilterNotNullOptionalExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Func<T?, bool> InternalCreateFilterNotNullOrThrowPredicate_Common<T>(Func<Exception> exceptionFactory)
            =>
            value => value is not null
                ? true
                : throw exceptionFactory.Invoke();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Func<T?, bool> InternalCreateFilterNotNullOrThrowPredicate_Struct<T>(Func<Exception> exceptionFactory)
            where T : struct
            =>
            value => value is not null
                ? true
                : throw exceptionFactory.Invoke();
    }
}
