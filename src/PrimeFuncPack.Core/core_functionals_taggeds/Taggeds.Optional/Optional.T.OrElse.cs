#nullable enable

using System.Threading.Tasks;

namespace System
{
    partial struct Optional<T>
    {
        public T OrElse(in T other)
        {
            var theOther = other;

            return ImplFold(value => value, () => theOther);
        }

        public T OrElse(in Func<T> otherFactory)
        {
            _ = otherFactory ?? throw new ArgumentNullException(nameof(otherFactory));

            return ImplFold(value => value, otherFactory);
        }

        public Task<T> OrElseAsync(in Func<Task<T>> otherFactoryAsync)
        {
            _ = otherFactoryAsync ?? throw new ArgumentNullException(nameof(otherFactoryAsync));

            return ImplFold(Task.FromResult, otherFactoryAsync);
        }

        public ValueTask<T> OrElseAsync(in Func<ValueTask<T>> otherFactoryAsync)
        {
            _ = otherFactoryAsync ?? throw new ArgumentNullException(nameof(otherFactoryAsync));

            return ImplFold(value => new ValueTask<T>(value), otherFactoryAsync);
        }
    }
}
