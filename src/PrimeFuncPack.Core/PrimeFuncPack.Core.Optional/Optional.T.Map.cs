#nullable enable

namespace System
{
    partial struct Optional<T>
    {
        public Optional<TResult> Map<TResult>(in Func<T, TResult> map)
        {
            if (map is null)
            {
                throw new ArgumentNullException(nameof(map));
            }

            return box switch
            {
                null => default,
                var present => Optional<TResult>.Present(map.Invoke(present))
            };
        }
    }
}
