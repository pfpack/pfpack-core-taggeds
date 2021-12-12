using System.Threading.Tasks;

namespace System;

partial struct Optional<T>
{
    public Optional<T> Or(Func<Optional<T>> otherFactory)
        =>
        InnerOr(
            otherFactory ?? throw new ArgumentNullException(nameof(otherFactory)));

    public Task<Optional<T>> OrAsync(Func<Task<Optional<T>>> otherFactoryAsync)
        =>
        InnerOrAsync(
            otherFactoryAsync ?? throw new ArgumentNullException(nameof(otherFactoryAsync)));

    public ValueTask<Optional<T>> OrValueAsync(Func<ValueTask<Optional<T>>> otherFactoryAsync)
        =>
        InnerOrValueAsync(
            otherFactoryAsync ?? throw new ArgumentNullException(nameof(otherFactoryAsync)));
}
