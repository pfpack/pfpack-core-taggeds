#nullable enable

using System.Threading.Tasks;

namespace System
{
    partial struct TaggedUnion<TFirst, TSecond>
    {
        // FoldOrThrow(Async)

        public TResult FoldOrThrow<TResult>(
            in Func<TFirst, TResult> onFirst,
            in Func<TSecond, TResult> onSecond)
            =>
            ImplFoldOrThrow(onFirst, onSecond);

        public Task<TResult> FoldOrThrowAsync<TResult>(
            in Func<TFirst, Task<TResult>> onFirstAsync,
            in Func<TSecond, Task<TResult>> onSecondAsync)
            =>
            ImplFoldOrThrow(onFirstAsync, onSecondAsync);

        public ValueTask<TResult> FoldOrThrowAsync<TResult>(
            in Func<TFirst, ValueTask<TResult>> onFirstAsync,
            in Func<TSecond, ValueTask<TResult>> onSecondAsync)
            =>
            ImplFoldOrThrow(onFirstAsync, onSecondAsync);

        // FoldOrElse

        public TResult FoldOrElse<TResult>(
            in Func<TFirst, TResult> onFirst,
            in Func<TSecond, TResult> onSecond,
            in TResult other)
            =>
            ImplFoldOrElse(onFirst, onSecond, other);

        public TResult FoldOrElse<TResult>(
            in Func<TFirst, TResult> onFirst,
            in Func<TSecond, TResult> onSecond,
            in Func<TResult> otherFactory)
            =>
            ImplFoldOrElse(onFirst, onSecond, otherFactory);

        // FoldOrElseAsync / Task

        public Task<TResult> FoldOrElseAsync<TResult>(
            in Func<TFirst, Task<TResult>> onFirstAsync,
            in Func<TSecond, Task<TResult>> onSecondAsync,
            in TResult other)
            =>
            ImplFoldOrElse(onFirstAsync, onSecondAsync, Task.FromResult(other));

        public Task<TResult> FoldOrElseAsync<TResult>(
            in Func<TFirst, Task<TResult>> onFirstAsync,
            in Func<TSecond, Task<TResult>> onSecondAsync,
            in Func<TResult> otherFactory)
        {
            _ = otherFactory ?? throw new ArgumentNullException(nameof(otherFactory));

            var theOtherFactory = otherFactory;

            return ImplFoldOrElse(onFirstAsync, onSecondAsync, () => Task.FromResult(theOtherFactory.Invoke()));
        }

        public Task<TResult> FoldOrElseAsync<TResult>(
            in Func<TFirst, Task<TResult>> onFirstAsync,
            in Func<TSecond, Task<TResult>> onSecondAsync,
            in Func<Task<TResult>> otherFactoryAsync)
            =>
            ImplFoldOrElse(onFirstAsync, onSecondAsync, otherFactoryAsync);

        // FoldOrElseAsync / ValueTask

        public ValueTask<TResult> FoldOrElseAsync<TResult>(
            in Func<TFirst, ValueTask<TResult>> onFirstAsync,
            in Func<TSecond, ValueTask<TResult>> onSecondAsync,
            in TResult other)
            =>
            ImplFoldOrElse(onFirstAsync, onSecondAsync, new ValueTask<TResult>(other));

        public ValueTask<TResult> FoldOrElseAsync<TResult>(
            in Func<TFirst, ValueTask<TResult>> onFirstAsync,
            in Func<TSecond, ValueTask<TResult>> onSecondAsync,
            in Func<TResult> otherFactory)
        {
            _ = otherFactory ?? throw new ArgumentNullException(nameof(otherFactory));

            var theOtherFactory = otherFactory;

            return ImplFoldOrElse(onFirstAsync, onSecondAsync, () => new ValueTask<TResult>(theOtherFactory.Invoke()));
        }

        public ValueTask<TResult> FoldOrElseAsync<TResult>(
            in Func<TFirst, ValueTask<TResult>> onFirstAsync,
            in Func<TSecond, ValueTask<TResult>> onSecondAsync,
            in Func<ValueTask<TResult>> otherFactoryAsync)
            =>
            ImplFoldOrElse(onFirstAsync, onSecondAsync, otherFactoryAsync);
    }
}
