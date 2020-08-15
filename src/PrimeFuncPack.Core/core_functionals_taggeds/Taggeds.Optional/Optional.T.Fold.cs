#nullable enable

using System.Threading.Tasks;

namespace System
{
    partial struct Optional<T>
    {
        public TResult Fold<TResult>(in Func<T, TResult> onPresent, in Func<TResult> onAbsent)
            =>
            ImplFold(onPresent, onAbsent);

        public Task<TResult> FoldAsync<TResult>(in Func<T, Task<TResult>> onPresentAsync, in Func<Task<TResult>> onAbsentAsync)
            =>
            ImplFold(onPresentAsync, onAbsentAsync);

        public ValueTask<TResult> FoldAsync<TResult>(in Func<T, ValueTask<TResult>> onPresentAsync, in Func<ValueTask<TResult>> onAbsentAsync)
            =>
            ImplFold(onPresentAsync, onAbsentAsync);

        public TResult Fold<TResult>(in Func<TResult> onPresent, in Func<TResult> onAbsent)
            =>
            ImplFold(onPresent, onAbsent);

        public Task<TResult> FoldAsync<TResult>(in Func<Task<TResult>> onPresentAsync, in Func<Task<TResult>> onAbsentAsync)
            =>
            ImplFold(onPresentAsync, onAbsentAsync);

        public ValueTask<TResult> FoldAsync<TResult>(in Func<ValueTask<TResult>> onPresentAsync, in Func<ValueTask<TResult>> onAbsentAsync)
            =>
            ImplFold(onPresentAsync, onAbsentAsync);
    }
}
