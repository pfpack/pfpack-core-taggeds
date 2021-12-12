using System.Threading.Tasks;

namespace System;

partial struct Optional<T>
{
    public Optional<TResult> Bind<TResult>(
        Func<T, Optional<TResult>> binder)
        =>
        InnerBindOrFlatMap(binder ?? throw new ArgumentNullException(nameof(binder)));

    public Task<Optional<TResult>> BindAsync<TResult>(
        Func<T, Task<Optional<TResult>>> binderAsync)
        =>
        InnerBindOrFlatMapAsync(binderAsync ?? throw new ArgumentNullException(nameof(binderAsync)));

    public ValueTask<Optional<TResult>> BindValueAsync<TResult>(
        Func<T, ValueTask<Optional<TResult>>> binderAsync)
        =>
        InnerBindOrFlatMapValueAsync(binderAsync ?? throw new ArgumentNullException(nameof(binderAsync)));
}
