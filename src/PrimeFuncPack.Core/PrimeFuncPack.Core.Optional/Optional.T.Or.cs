#nullable enable

using System.Threading.Tasks;

namespace System
{
    partial struct Optional<T>
    {
        public Optional<T> Or(in Func<Optional<T>> otherFactory)
        {
            _ = otherFactory ?? throw new ArgumentNullException(nameof(otherFactory));

            return ImplFold(This, otherFactory);
        }

        public Task<Optional<T>> OrAsync(in Func<Task<Optional<T>>> otherFactoryAsync)
        {
            _ = otherFactoryAsync ?? throw new ArgumentNullException(nameof(otherFactoryAsync));

            return ImplFold(ThisAsync, otherFactoryAsync);
        }

        public ValueTask<Optional<T>> OrAsync(in Func<ValueTask<Optional<T>>> otherFactoryAsync)
        {
            _ = otherFactoryAsync ?? throw new ArgumentNullException(nameof(otherFactoryAsync));

            return ImplFold(ThisValueAsync, otherFactoryAsync);
        }
    }
}
