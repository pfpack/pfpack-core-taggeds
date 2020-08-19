#nullable enable

using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

namespace System
{
    partial struct TaggedUnion<TFirst, TSecond>
    {
        // Fold

        [return: MaybeNull]
        public TResult Fold<TResult>(
            in Func<TFirst, TResult> onFirst,
            in Func<TSecond, TResult> onSecond)
            =>
            ImplFold(onFirst, onSecond).OrElse(() => default!);

        public TResult Fold<TResult>(
            in Func<TFirst, TResult> onFirst,
            in Func<TSecond, TResult> onSecond,
            in TResult other)
            =>
            ImplFold(onFirst, onSecond).OrElse(other);

        public TResult Fold<TResult>(
            in Func<TFirst, TResult> onFirst,
            in Func<TSecond, TResult> onSecond,
            in Func<TResult> otherFactory)
            =>
            ImplFold(onFirst, onSecond).OrElse(otherFactory);

        // FoldAsync / Task

        public Task<TResult> FoldAsync<TResult>(
            in Func<TFirst, Task<TResult>> onFirstAsync,
            in Func<TSecond, Task<TResult>> onSecondAsync,
            in TResult other)
            =>
            ImplFold(onFirstAsync, onSecondAsync).OrElse(Task.FromResult(other));

        public Task<TResult> FoldAsync<TResult>(
            in Func<TFirst, Task<TResult>> onFirstAsync,
            in Func<TSecond, Task<TResult>> onSecondAsync,
            in Func<TResult> otherFactory)
        {
            _ = otherFactory ?? throw new ArgumentNullException(nameof(otherFactory));

            var theOtherFactory = otherFactory;

            return ImplFold(onFirstAsync, onSecondAsync).OrElse(() => Task.FromResult(theOtherFactory.Invoke()));
        }

        public Task<TResult> FoldAsync<TResult>(
            in Func<TFirst, Task<TResult>> onFirstAsync,
            in Func<TSecond, Task<TResult>> onSecondAsync,
            in Func<Task<TResult>> otherFactoryAsync)
            =>
            ImplFold(onFirstAsync, onSecondAsync).OrElse(otherFactoryAsync);

        // FoldAsync / ValueTask

        public ValueTask<TResult> FoldAsync<TResult>(
            in Func<TFirst, ValueTask<TResult>> onFirstAsync,
            in Func<TSecond, ValueTask<TResult>> onSecondAsync,
            in TResult other)
            =>
            ImplFold(onFirstAsync, onSecondAsync).OrElse(ValueTask.FromResult(other));

        public ValueTask<TResult> FoldAsync<TResult>(
            in Func<TFirst, ValueTask<TResult>> onFirstAsync,
            in Func<TSecond, ValueTask<TResult>> onSecondAsync,
            in Func<TResult> otherFactory)
        {
            _ = otherFactory ?? throw new ArgumentNullException(nameof(otherFactory));

            var theOtherFactory = otherFactory;

            return ImplFold(onFirstAsync, onSecondAsync).OrElse(() => ValueTask.FromResult(theOtherFactory.Invoke()));
        }

        public ValueTask<TResult> FoldAsync<TResult>(
            in Func<TFirst, ValueTask<TResult>> onFirstAsync,
            in Func<TSecond, ValueTask<TResult>> onSecondAsync,
            in Func<ValueTask<TResult>> otherFactoryAsync)
            =>
            ImplFold(onFirstAsync, onSecondAsync).OrElse(otherFactoryAsync);
    }
}
