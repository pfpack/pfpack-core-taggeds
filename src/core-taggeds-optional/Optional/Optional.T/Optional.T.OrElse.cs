#nullable enable

using System.Threading.Tasks;

namespace System
{
    partial struct Optional<T>
    {
        public T OrElse(T other)
            =>
            InternalHandleFold(Pipeline.Pipe, other);

        public T OrElse(Func<T> otherFactory)
        {
            _ = otherFactory ?? throw new ArgumentNullException(nameof(otherFactory));

            return InternalHandleFold(Pipeline.Pipe, otherFactory);
        }

        public Task<T> OrElseAsync(Func<Task<T>> otherFactoryAsync)
        {
            _ = otherFactoryAsync ?? throw new ArgumentNullException(nameof(otherFactoryAsync));

            return InternalHandleFold(Task.FromResult, otherFactoryAsync);
        }

        public ValueTask<T> OrElseValueAsync(Func<ValueTask<T>> otherFactoryAsync)
        {
            _ = otherFactoryAsync ?? throw new ArgumentNullException(nameof(otherFactoryAsync));

            return InternalHandleFold(ValueTask.FromResult, otherFactoryAsync);
        }
    }
}
