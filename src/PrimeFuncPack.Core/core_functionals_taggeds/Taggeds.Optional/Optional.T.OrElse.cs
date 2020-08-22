#nullable enable

using System.Threading.Tasks;

namespace System
{
    partial struct Optional<T>
    {
        public T OrElse(T other)
            =>
            ImplFold(Pipeline.Pipe, () => other);

        public T OrElse(Func<T> otherFactory)
        {
            _ = otherFactory ?? throw new ArgumentNullException(nameof(otherFactory));

            return ImplFold(Pipeline.Pipe, otherFactory);
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
