#nullable enable

using System.Threading.Tasks;

namespace System
{
    partial struct Optional<T>
    {
        public T OrElse(T other)
            =>
            Fold(Pipeline.Pipe, () => other);

        public T OrElse(Func<T> otherFactory)
            =>
            Fold(Pipeline.Pipe, otherFactory);

        public Task<T> OrElseAsync(Func<Task<T>> otherFactoryAsync)
            =>
            FoldAsync(Task.FromResult, otherFactoryAsync);

        public ValueTask<T> OrElseValueAsync(Func<ValueTask<T>> otherFactoryAsync)
            =>
            FoldValueAsync(ValueTask.FromResult, otherFactoryAsync);
    }
}
