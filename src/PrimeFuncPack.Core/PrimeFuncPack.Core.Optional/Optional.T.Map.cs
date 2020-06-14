#nullable enable

namespace System
{
    partial struct Optional<T>
    {
        public Optional<TResult> Map<TResult>(in Func<T, TResult> map)
            =>
            box switch
            {
                null => default,
                var present => Optional<TResult>.Present(map.Invoke(present))
            };
    }
}
