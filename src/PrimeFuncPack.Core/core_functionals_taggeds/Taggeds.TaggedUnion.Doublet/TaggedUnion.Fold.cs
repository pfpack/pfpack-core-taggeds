#nullable enable

using System.Threading.Tasks;

namespace System
{
    partial struct TaggedUnion<TFirst, TSecond>
    {
        // FoldOrAbsent(Async)

        public Optional<TResult> FoldOrAbsent<TResult>(
            in Func<TFirst, TResult> onFirst,
            in Func<TSecond, TResult> onSecond)
            =>
            ImplFold(onFirst, onSecond);

        public Optional<Task<TResult>> FoldOrAbsentAsync<TResult>(
            in Func<TFirst, Task<TResult>> onFirstAsync,
            in Func<TSecond, Task<TResult>> onSecondAsync)
            =>
            ImplFold(onFirstAsync, onSecondAsync);

        public Optional<ValueTask<TResult>> FoldOrAbsentAsync<TResult>(
            in Func<TFirst, ValueTask<TResult>> onFirstAsync,
            in Func<TSecond, ValueTask<TResult>> onSecondAsync)
            =>
            ImplFold(onFirstAsync, onSecondAsync);

        // FoldOrElse

        public TResult FoldOrElse<TResult>(
            in Func<TFirst, TResult> onFirst,
            in Func<TSecond, TResult> onSecond,
            in TResult other)
            =>
            ImplFold(onFirst, onSecond).OrElse(other);

        public TResult FoldOrElse<TResult>(
            in Func<TFirst, TResult> onFirst,
            in Func<TSecond, TResult> onSecond,
            in Func<TResult> otherFactory)
            =>
            ImplFold(onFirst, onSecond).OrElse(otherFactory);

        // FoldOrElseAsync / Task

        public Task<TResult> FoldOrElseAsync<TResult>(
            in Func<TFirst, Task<TResult>> onFirstAsync,
            in Func<TSecond, Task<TResult>> onSecondAsync,
            in TResult other)
            =>
            ImplFold(onFirstAsync, onSecondAsync).OrElse(Task.FromResult(other));

        public Task<TResult> FoldOrElseAsync<TResult>(
            in Func<TFirst, Task<TResult>> onFirstAsync,
            in Func<TSecond, Task<TResult>> onSecondAsync,
            in Func<TResult> otherFactory)
        {
            _ = otherFactory ?? throw new ArgumentNullException(nameof(otherFactory));

            var theOtherFactory = otherFactory;

            return ImplFold(onFirstAsync, onSecondAsync).OrElse(() => Task.FromResult(theOtherFactory.Invoke()));
        }

        public Task<TResult> FoldOrElseAsync<TResult>(
            in Func<TFirst, Task<TResult>> onFirstAsync,
            in Func<TSecond, Task<TResult>> onSecondAsync,
            in Func<Task<TResult>> otherFactoryAsync)
            =>
            ImplFold(onFirstAsync, onSecondAsync).OrElse(otherFactoryAsync);

        // FoldOrElseAsync / ValueTask

        public ValueTask<TResult> FoldOrElseAsync<TResult>(
            in Func<TFirst, ValueTask<TResult>> onFirstAsync,
            in Func<TSecond, ValueTask<TResult>> onSecondAsync,
            in TResult other)
            =>
            ImplFold(onFirstAsync, onSecondAsync).OrElse(new ValueTask<TResult>(other));

        public ValueTask<TResult> FoldOrElseAsync<TResult>(
            in Func<TFirst, ValueTask<TResult>> onFirstAsync,
            in Func<TSecond, ValueTask<TResult>> onSecondAsync,
            in Func<TResult> otherFactory)
        {
            _ = otherFactory ?? throw new ArgumentNullException(nameof(otherFactory));

            var theOtherFactory = otherFactory;

            return ImplFold(onFirstAsync, onSecondAsync).OrElse(() => new ValueTask<TResult>(theOtherFactory.Invoke()));
        }

        public ValueTask<TResult> FoldOrElseAsync<TResult>(
            in Func<TFirst, ValueTask<TResult>> onFirstAsync,
            in Func<TSecond, ValueTask<TResult>> onSecondAsync,
            in Func<ValueTask<TResult>> otherFactoryAsync)
            =>
            ImplFold(onFirstAsync, onSecondAsync).OrElse(otherFactoryAsync);
    }
}
