#nullable enable

using System.Threading.Tasks;

namespace System
{
    partial struct Optional<T>
    {
        public Optional<T> Or(Func<Optional<T>> otherFactory)
        {
            _ = otherFactory ?? throw new ArgumentNullException(nameof(otherFactory));

            return InternalHandleFoldThis(Pipeline.Pipe, otherFactory);
        }

        public Task<Optional<T>> OrAsync(Func<Task<Optional<T>>> otherFactoryAsync)
        {
            _ = otherFactoryAsync ?? throw new ArgumentNullException(nameof(otherFactoryAsync));

            return InternalHandleFoldThis(Task.FromResult, otherFactoryAsync);
        }

        public ValueTask<Optional<T>> OrValueAsync(Func<ValueTask<Optional<T>>> otherFactoryAsync)
        {
            _ = otherFactoryAsync ?? throw new ArgumentNullException(nameof(otherFactoryAsync));

            return InternalHandleFoldThis(ValueTask.FromResult, otherFactoryAsync);
        }
    }
}
