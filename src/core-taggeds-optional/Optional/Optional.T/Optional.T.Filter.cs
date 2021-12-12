using System.Threading.Tasks;

namespace System;

partial struct Optional<T>
{
    public Optional<T> Filter(Func<T, bool> predicate)
        =>
        InnerFilter(
            predicate ?? throw new ArgumentNullException(nameof(predicate)));

    public Task<Optional<T>> FilterAsync(Func<T, Task<bool>> predicateAsync)
        =>
        InnerFilterAsync(
            predicateAsync ?? throw new ArgumentNullException(nameof(predicateAsync)));

    public ValueTask<Optional<T>> FilterValueAsync(Func<T, ValueTask<bool>> predicateAsync)
        =>
        InnerFilterValueAsync(
            predicateAsync ?? throw new ArgumentNullException(nameof(predicateAsync)));
}
