#nullable enable

namespace System
{
    partial struct Optional<T>
    {
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
