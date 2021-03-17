#nullable enable

using System.Threading.Tasks;

namespace System
{
    partial struct Optional<T>
    {
        public T OrElse(T other)
            =>
            InternalHandleFold(
                Pipeline.Pipe,
                () => other);

        public T OrElse(Func<T> otherFactory)
            =>
            InternalHandleFold(
                Pipeline.Pipe,
                otherFactory ?? throw new ArgumentNullException(nameof(otherFactory)));

        public Task<T> OrElseAsync(Func<Task<T>> otherFactoryAsync)
            =>
            InternalHandleFold(
                Task.FromResult,
                otherFactoryAsync ?? throw new ArgumentNullException(nameof(otherFactoryAsync)));

        public ValueTask<T> OrElseValueAsync(Func<ValueTask<T>> otherFactoryAsync)
            =>
            InternalHandleFold(
                ValueTask.FromResult,
                otherFactoryAsync ?? throw new ArgumentNullException(nameof(otherFactoryAsync)));
    }
}
