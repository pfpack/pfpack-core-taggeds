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
            Func<TFirst, TResult> onFirst,
            Func<TSecond, TResult> onSecond)
            =>
            ImplFold(onFirst, onSecond).OrElse(() => default!);

        public TResult Fold<TResult>(
            Func<TFirst, TResult> onFirst,
            Func<TSecond, TResult> onSecond,
            TResult @default)
            =>
            ImplFold(onFirst, onSecond).OrElse(@default);

        public TResult Fold<TResult>(
            Func<TFirst, TResult> onFirst,
            Func<TSecond, TResult> onSecond,
            Func<TResult> defaultFactory)
            =>
            ImplFold(onFirst, onSecond).OrElse(defaultFactory);

        // FoldAsync / Task

        public Task<TResult> FoldAsync<TResult>(
            Func<TFirst, Task<TResult>> onFirstAsync,
            Func<TSecond, Task<TResult>> onSecondAsync,
            TResult @default)
            =>
            ImplFold(onFirstAsync, onSecondAsync).OrElse(Task.FromResult(@default));

        public Task<TResult> FoldAsync<TResult>(
            Func<TFirst, Task<TResult>> onFirstAsync,
            Func<TSecond, Task<TResult>> onSecondAsync,
            Func<TResult> defaultFactory)
        {
            _ = defaultFactory ?? throw new ArgumentNullException(nameof(defaultFactory));

            return ImplFold(onFirstAsync, onSecondAsync).OrElse(() => Task.FromResult(defaultFactory.Invoke()));
        }

        public Task<TResult> FoldAsync<TResult>(
            Func<TFirst, Task<TResult>> onFirstAsync,
            Func<TSecond, Task<TResult>> onSecondAsync,
            Func<Task<TResult>> defaultFactoryAsync)
            =>
            ImplFold(onFirstAsync, onSecondAsync).OrElse(defaultFactoryAsync);

        // FoldAsync / ValueTask

        public ValueTask<TResult> FoldAsync<TResult>(
            Func<TFirst, ValueTask<TResult>> onFirstAsync,
            Func<TSecond, ValueTask<TResult>> onSecondAsync,
            TResult @default)
            =>
            ImplFold(onFirstAsync, onSecondAsync).OrElse(ValueTask.FromResult(@default));

        public ValueTask<TResult> FoldAsync<TResult>(
            Func<TFirst, ValueTask<TResult>> onFirstAsync,
            Func<TSecond, ValueTask<TResult>> onSecondAsync,
            Func<TResult> defaultFactory)
        {
            _ = defaultFactory ?? throw new ArgumentNullException(nameof(defaultFactory));

            return ImplFold(onFirstAsync, onSecondAsync).OrElse(() => ValueTask.FromResult(defaultFactory.Invoke()));
        }

        public ValueTask<TResult> FoldAsync<TResult>(
            Func<TFirst, ValueTask<TResult>> onFirstAsync,
            Func<TSecond, ValueTask<TResult>> onSecondAsync,
            Func<ValueTask<TResult>> defaultFactoryAsync)
            =>
            ImplFold(onFirstAsync, onSecondAsync).OrElse(defaultFactoryAsync);
    }
}
