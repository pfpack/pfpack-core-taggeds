#nullable enable

using System.Threading.Tasks;

namespace System
{
    partial struct Optional<T>
    {
        public T OrElse(T other) => ImplFold(
            Pipeline.Pipe,
            () => other);

        public T OrElse(Func<T> otherFactory) => ImplFold(
            Pipeline.Pipe,
            otherFactory ?? throw new ArgumentNullException(nameof(otherFactory)));

        public Task<T> OrElseAsync(Func<Task<T>> otherFactoryAsync) => ImplFold(
            Task.FromResult,
            otherFactoryAsync ?? throw new ArgumentNullException(nameof(otherFactoryAsync)));

        public ValueTask<T> OrElseAsync(Func<ValueTask<T>> otherFactoryAsync) => ImplFold(
            ValueTask.FromResult,
            otherFactoryAsync ?? throw new ArgumentNullException(nameof(otherFactoryAsync)));
    }
}
