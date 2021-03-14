#nullable enable

using System.Runtime.CompilerServices;

namespace System
{
    partial struct Optional<T>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private TResult InternalHandle<TSource, TResult>(
            Func<TSource> supplier,
            Func<TSource, TResult> onPresent,
            Func<TResult> onElse)
            =>
            hasValue
                ? onPresent.Invoke(supplier.Invoke())
                : onElse.Invoke();
    }
}
