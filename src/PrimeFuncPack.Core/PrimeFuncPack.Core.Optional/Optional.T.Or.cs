#nullable enable

using System.Threading.Tasks;

namespace System
{
    partial struct Optional<T>
    {
        public Optional<T> Or(in Func<Optional<T>> otherFactory)
        {
            if (otherFactory is null)
            {
                throw new ArgumentNullException(nameof(otherFactory));
            }

            return ImplFold(This, otherFactory);
        }

        public Task<Optional<T>> OrAsync(in Func<Task<Optional<T>>> otherFactoryAsync)
        {
            if (otherFactoryAsync is null)
            {
                throw new ArgumentNullException(nameof(otherFactoryAsync));
            }

            return ImplFold(ThisAsync, otherFactoryAsync);
        }
    }
}
