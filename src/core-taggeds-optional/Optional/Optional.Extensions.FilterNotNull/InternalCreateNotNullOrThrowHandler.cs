#nullable enable

using System.Runtime.CompilerServices;

namespace System
{
    partial class FilterNotNullOptionalExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Func<T?, Unit> InternalCreateNotNullOrThrowHandler_Common<T>(Func<Exception> exceptionFactory)
            =>
            value => value is not null
                ? default
                : throw exceptionFactory.Invoke();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Func<T?, Unit> InternalCreateNotNullOrThrowHandler_Struct<T>(Func<Exception> exceptionFactory)
            where T : struct
            =>
            value => value is not null
                ? default
                : throw exceptionFactory.Invoke();
    }
}
