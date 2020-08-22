#nullable enable

namespace System
{
    partial struct Optional<T>
    {
        public Optional<TResult> Map<TResult>(Func<T, TResult> map)
        {
            _ = map ?? throw new ArgumentNullException(nameof(map));

            return ImplFold(Map, () => default);

            Optional<TResult> Map(T value) => Optional<TResult>.Present(map.Invoke(value));
        }
    }
}
