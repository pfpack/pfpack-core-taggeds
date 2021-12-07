using System.Threading.Tasks;

namespace System;

partial struct Optional<T>
{
    public T OrElse(T other)
        =>
        InnerOrElse(other);

    public T OrElse(Func<T> otherFactory)
        =>
        InnerOrElse(otherFactory ?? throw new ArgumentNullException(nameof(otherFactory)));

    public Task<T> OrElseAsync(Func<Task<T>> otherFactoryAsync)
        =>
        InnerFold(
            Task.FromResult,
            otherFactoryAsync ?? throw new ArgumentNullException(nameof(otherFactoryAsync)));

    public ValueTask<T> OrElseValueAsync(Func<ValueTask<T>> otherFactoryAsync)
        =>
        InnerFold(
            ValueTask.FromResult,
            otherFactoryAsync ?? throw new ArgumentNullException(nameof(otherFactoryAsync)));
}
