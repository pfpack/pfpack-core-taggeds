#nullable enable

using System.Threading.Tasks;

namespace System
{
    partial struct Optional<T>
    {
        public Optional<T> Filter(Func<T, bool> predicate)
        {
            _ = predicate ?? throw new ArgumentNullException(nameof(predicate));

            return InternalFold(value => FilterPresent(value, predicate, This), This);

            static Optional<T> FilterPresent(T value, Func<T, bool> predicate, Func<Optional<T>> thisSupplier)
                =>
                predicate.Invoke(value)
                    ? thisSupplier.Invoke()
                    : default;
        }

        public Task<Optional<T>> FilterAsync(Func<T, Task<bool>> predicateAsync)
        {
            _ = predicateAsync ?? throw new ArgumentNullException(nameof(predicateAsync));

            return InternalFold(value => FilterPresentAsync(value, predicateAsync, This), ThisAsync);

            static async Task<Optional<T>> FilterPresentAsync(
                T value, Func<T, Task<bool>> predicateAsync, Func<Optional<T>> thisSupplier)
                =>
                await predicateAsync.Invoke(value).ConfigureAwait(false)
                    ? thisSupplier.Invoke()
                    : default;
        }

        public ValueTask<Optional<T>> FilterValueAsync(Func<T, ValueTask<bool>> predicateAsync)
        {
            _ = predicateAsync ?? throw new ArgumentNullException(nameof(predicateAsync));

            return InternalFold(value => FilterPresentAsync(value, predicateAsync, This), ThisValueAsync);

            static async ValueTask<Optional<T>> FilterPresentAsync(
                T value, Func<T, ValueTask<bool>> predicateAsync, Func<Optional<T>> thisSupplier)
                =>
                await predicateAsync.Invoke(value).ConfigureAwait(false)
                    ? thisSupplier.Invoke()
                    : default;
        }
    }
}
