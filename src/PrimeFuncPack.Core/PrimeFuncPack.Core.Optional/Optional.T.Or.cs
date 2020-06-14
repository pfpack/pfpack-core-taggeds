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

            return box switch
            {
                null => otherFactory.Invoke(),
                _ => this
            };
        }

        public Task<Optional<T>> OrAsync(in Func<Task<Optional<T>>> otherFactory)
        {
            if (otherFactory is null)
            {
                throw new ArgumentNullException(nameof(otherFactory));
            }

            return box switch
            {
                null => otherFactory.Invoke(),
                _ => Task.FromResult(this)
            };
        }
    }
}
