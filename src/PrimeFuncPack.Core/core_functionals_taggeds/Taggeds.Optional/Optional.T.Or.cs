#nullable enable

using System.Threading.Tasks;

namespace System
{
    partial struct Optional<T>
    {
        public Optional<T> Or(Func<Optional<T>> otherFactory)
            =>
            InternalOr(
                Pipeline.Pipe,
                otherFactory ?? throw new ArgumentNullException(nameof(otherFactory)));

        public Task<Optional<T>> OrAsync(Func<Task<Optional<T>>> otherFactoryAsync)
            =>
            InternalOr(
                Task.FromResult,
                otherFactoryAsync ?? throw new ArgumentNullException(nameof(otherFactoryAsync)));

        public ValueTask<Optional<T>> OrValueAsync(Func<ValueTask<Optional<T>>> otherFactoryAsync)
            =>
            InternalOr(
                ValueTask.FromResult,
                otherFactoryAsync ?? throw new ArgumentNullException(nameof(otherFactoryAsync)));
    }
}
