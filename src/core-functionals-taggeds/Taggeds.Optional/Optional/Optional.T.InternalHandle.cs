#nullable enable

namespace System
{
    partial struct Optional<T>
    {
        private TResult InternalHandle<TSource, TResult>(
            Func<TSource> supplier,
            Func<TSource, TResult> onPresent,
            Func<TResult> onElse)
        {
            if (hasValue)
            {
                return onPresent.Invoke(supplier.Invoke());
            }

            return onElse.Invoke();
        }
    }
}
