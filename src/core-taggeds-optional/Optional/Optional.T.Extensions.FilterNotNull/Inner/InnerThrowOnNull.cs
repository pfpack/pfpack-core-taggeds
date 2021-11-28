using System.Runtime.CompilerServices;

namespace System
{
    partial class FilterNotNullOptionalExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Unit InnerThrowOnNull<T>(this T? value, Func<Exception> exceptionFactory)
            =>
            value is not null
                ? default
                : throw exceptionFactory.Invoke();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Unit InnerThrowOnNull<T>(this T? value, Func<Exception> exceptionFactory)
            where T : struct
            =>
            value is not null
                ? default
                : throw exceptionFactory.Invoke();
    }
}
