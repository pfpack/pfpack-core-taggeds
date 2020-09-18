#nullable enable

using System.Threading.Tasks;

namespace System
{
    partial struct Optional<T>
    {
        public Optional<T> Filter(Func<T, bool> predicate)
        {
            _ = predicate ?? throw new ArgumentNullException(nameof(predicate));

            var @this = this;

            return Fold(FilterPresent, () => @this);

            Optional<T> FilterPresent(T value)
                =>
                predicate.Invoke(value) switch
                {
                    true => @this,
                    _ => default
                };
        }

        public Task<Optional<T>> FilterAsync(Func<T, Task<bool>> predicateAsync)
        {
            _ = predicateAsync ?? throw new ArgumentNullException(nameof(predicateAsync));

            var @this = this;

            return FoldAsync(FilterPresentAsync, () => @this);

            async Task<Optional<T>> FilterPresentAsync(T value)
                =>
                await predicateAsync.Invoke(value).ConfigureAwait(false) switch
                {
                    true => @this,
                    _ => default
                };
        }

        public ValueTask<Optional<T>> FilterValueAsync(Func<T, ValueTask<bool>> predicateAsync)
        {
            _ = predicateAsync ?? throw new ArgumentNullException(nameof(predicateAsync));

            var @this = this;

            return FoldValueAsync(FilterPresentValueAsync, () => @this);

            async ValueTask<Optional<T>> FilterPresentValueAsync(T value)
                =>
                await predicateAsync.Invoke(value).ConfigureAwait(false) switch
                {
                    true => @this,
                    _ => default
                };
        }
    }
}
