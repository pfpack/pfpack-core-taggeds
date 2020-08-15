#nullable enable

namespace System
{
    partial struct Optional<T>
    {
        public Optional<TResult> Map<TResult>(in Func<T, TResult> map)
        {
            _ = map ?? throw new ArgumentNullException(nameof(map));

            var theMap = map;

            return ImplFold(Map, () => default);

            Optional<TResult> Map(T value) => Optional<TResult>.Present(theMap.Invoke(value));
        }
    }
}
