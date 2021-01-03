#nullable enable

using System.Threading.Tasks;

namespace System
{
    partial struct Optional<T>
    {
        public T OrElse(T other)
            =>
            InternalFold(
                Pipeline.Pipe,
                () => other);

        public T OrElse(Func<T> otherFactory)
            =>
            InternalFold(
                Pipeline.Pipe,
                otherFactory ?? throw new ArgumentNullException(nameof(otherFactory)));

        public Task<T> OrElseAsync(Func<Task<T>> otherFactoryAsync)
            =>
            InternalFold(
                Task.FromResult,
                otherFactoryAsync ?? throw new ArgumentNullException(nameof(otherFactoryAsync)));

        public ValueTask<T> OrElseValueAsync(Func<ValueTask<T>> otherFactoryAsync)
            =>
            InternalFold(
                ValueTask.FromResult,
                otherFactoryAsync ?? throw new ArgumentNullException(nameof(otherFactoryAsync)));
    }
}
