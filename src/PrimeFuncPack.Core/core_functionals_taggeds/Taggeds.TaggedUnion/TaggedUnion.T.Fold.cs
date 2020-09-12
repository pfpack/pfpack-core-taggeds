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
            Func<TFirst, TResult> mapFirst,
            Func<TSecond, TResult> mapSecond)
            =>
            ImplFold(mapFirst, mapSecond).OrElse(() => default!);

        public TResult Fold<TResult>(
            Func<TFirst, TResult> mapFirst,
            Func<TSecond, TResult> mapSecond,
            TResult other)
            =>
            ImplFold(mapFirst, mapSecond).OrElse(other);

        public TResult Fold<TResult>(
            Func<TFirst, TResult> mapFirst,
            Func<TSecond, TResult> mapSecond,
            Func<TResult> otherFactory)
        {
            _ = otherFactory ?? throw new ArgumentNullException(nameof(otherFactory));

            return ImplFold(mapFirst, mapSecond).OrElse(otherFactory);
        }

        // Fold Async / Task

        public Task<TResult> FoldAsync<TResult>(
            Func<TFirst, Task<TResult>> mapFirstAsync,
            Func<TSecond, Task<TResult>> mapSecondAsync,
            TResult other)
            =>
            ImplFold(mapFirstAsync, mapSecondAsync).OrElse(Task.FromResult(other));

        public Task<TResult> FoldAsync<TResult>(
            Func<TFirst, Task<TResult>> mapFirstAsync,
            Func<TSecond, Task<TResult>> mapSecondAsync,
            Func<TResult> otherFactory)
        {
            _ = otherFactory ?? throw new ArgumentNullException(nameof(otherFactory));

            return ImplFold(mapFirstAsync, mapSecondAsync).OrElse(() => Task.FromResult(otherFactory.Invoke()));
        }

        public Task<TResult> FoldAsync<TResult>(
            Func<TFirst, Task<TResult>> mapFirstAsync,
            Func<TSecond, Task<TResult>> mapSecondAsync,
            Func<Task<TResult>> otherFactoryAsync)
        {
            _ = otherFactoryAsync ?? throw new ArgumentNullException(nameof(otherFactoryAsync));

            return ImplFold(mapFirstAsync, mapSecondAsync).OrElse(otherFactoryAsync);
        }

        // Fold Async / ValueTask

        public ValueTask<TResult> FoldValueAsync<TResult>(
            Func<TFirst, ValueTask<TResult>> mapFirstAsync,
            Func<TSecond, ValueTask<TResult>> mapSecondAsync,
            TResult other)
            =>
            ImplFold(mapFirstAsync, mapSecondAsync).OrElse(ValueTask.FromResult(other));

        public ValueTask<TResult> FoldValueAsync<TResult>(
            Func<TFirst, ValueTask<TResult>> mapFirstAsync,
            Func<TSecond, ValueTask<TResult>> mapSecondAsync,
            Func<TResult> otherFactory)
        {
            _ = otherFactory ?? throw new ArgumentNullException(nameof(otherFactory));

            return ImplFold(mapFirstAsync, mapSecondAsync).OrElse(() => ValueTask.FromResult(otherFactory.Invoke()));
        }

        public ValueTask<TResult> FoldValueAsync<TResult>(
            Func<TFirst, ValueTask<TResult>> mapFirstAsync,
            Func<TSecond, ValueTask<TResult>> mapSecondAsync,
            Func<ValueTask<TResult>> otherFactoryAsync)
        {
            _ = otherFactoryAsync ?? throw new ArgumentNullException(nameof(otherFactoryAsync));

            return ImplFold(mapFirstAsync, mapSecondAsync).OrElse(otherFactoryAsync);
        }
    }
}
