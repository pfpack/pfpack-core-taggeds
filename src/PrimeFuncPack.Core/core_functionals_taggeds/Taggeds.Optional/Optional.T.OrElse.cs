#nullable enable

using System.Threading.Tasks;

namespace System
{
    partial struct Optional<T>
    {
        public T OrElse(T other)
            =>
            ImplFold(Do.Pass, () => other);

        public T OrElse(Func<T> otherFactory)
        {
            _ = otherFactory ?? throw new ArgumentNullException(nameof(otherFactory));

            return ImplFold(Do.Pass, otherFactory);
        }

        public Task<T> OrElseAsync(Func<Task<T>> otherFactoryAsync)
        {
            _ = otherFactoryAsync ?? throw new ArgumentNullException(nameof(otherFactoryAsync));

            return ImplFold(Task.FromResult, otherFactoryAsync);
        }

        public ValueTask<T> OrElseAsync(Func<ValueTask<T>> otherFactoryAsync)
        {
            _ = otherFactoryAsync ?? throw new ArgumentNullException(nameof(otherFactoryAsync));

            return ImplFold(ValueTask.FromResult, otherFactoryAsync);
        }
    }
}
