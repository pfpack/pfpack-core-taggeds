#nullable enable

using System.Threading.Tasks;

namespace System
{
    partial struct Optional<T>
    {
        public Optional<T> Or(Func<Optional<T>> otherFactory)
            =>
            ImplOr(Pipeline.Pipe, otherFactory);

        public Task<Optional<T>> OrAsync(Func<Task<Optional<T>>> otherFactoryAsync)
            =>
            ImplOr(Task.FromResult, otherFactoryAsync);

        public ValueTask<Optional<T>> OrValueAsync(Func<ValueTask<Optional<T>>> otherFactoryAsync)
            =>
            ImplOr(ValueTask.FromResult, otherFactoryAsync);
    }
}
