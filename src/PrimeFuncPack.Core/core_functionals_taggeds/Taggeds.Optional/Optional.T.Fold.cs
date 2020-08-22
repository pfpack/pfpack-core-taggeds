#nullable enable

using System.Threading.Tasks;

namespace System
{
    partial struct Optional<T>
    {
        public TResult Fold<TResult>(Func<T, TResult> onPresent, Func<TResult> onAbsent)
            =>
            ImplFold(onPresent, onAbsent);

        public Task<TResult> FoldAsync<TResult>(Func<T, Task<TResult>> onPresentAsync, Func<Task<TResult>> onAbsentAsync)
            =>
            ImplFold(onPresentAsync, onAbsentAsync);

        public ValueTask<TResult> FoldAsync<TResult>(Func<T, ValueTask<TResult>> onPresentAsync, Func<ValueTask<TResult>> onAbsentAsync)
            =>
            ImplFold(onPresentAsync, onAbsentAsync);

        public TResult Fold<TResult>(Func<TResult> onPresent, Func<TResult> onAbsent)
            =>
            ImplFold(onPresent, onAbsent);

        public Task<TResult> FoldAsync<TResult>(Func<Task<TResult>> onPresentAsync, Func<Task<TResult>> onAbsentAsync)
            =>
            ImplFold(onPresentAsync, onAbsentAsync);

        public ValueTask<TResult> FoldAsync<TResult>(Func<ValueTask<TResult>> onPresentAsync, Func<ValueTask<TResult>> onAbsentAsync)
            =>
            ImplFold(onPresentAsync, onAbsentAsync);
    }
}
