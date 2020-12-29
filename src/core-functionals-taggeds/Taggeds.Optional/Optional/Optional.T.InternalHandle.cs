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
            hasValue switch
            {
                true => onPresent.Invoke(supplier.Invoke()),
                _ => onElse.Invoke()
            };
    }
}
