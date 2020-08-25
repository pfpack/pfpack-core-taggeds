#nullable enable

using System.Threading.Tasks;

namespace System
{
    partial struct Optional<T>
    {
        public Optional<T> Or(Func<Optional<T>> otherFactory) => ImplFold(
            This,
            otherFactory ?? throw new ArgumentNullException(nameof(otherFactory)));

        public Task<Optional<T>> OrAsync(Func<Task<Optional<T>>> otherFactoryAsync) => ImplFold(
            ThisAsync,
            otherFactoryAsync ?? throw new ArgumentNullException(nameof(otherFactoryAsync)));

        public ValueTask<Optional<T>> OrAsync(Func<ValueTask<Optional<T>>> otherFactoryAsync) => ImplFold(
            ThisValueAsync,
            otherFactoryAsync ?? throw new ArgumentNullException(nameof(otherFactoryAsync)));
    }
}
