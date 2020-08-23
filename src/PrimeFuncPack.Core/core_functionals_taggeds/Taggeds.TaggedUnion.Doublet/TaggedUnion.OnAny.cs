#nullable enable

using System.Threading.Tasks;

namespace System
{
    partial struct TaggedUnion<TFirst, TSecond>
    {
        // Parameterized

        public TaggedUnion<TFirst, TSecond> OnAny(
            Func<TFirst, Unit> onFirst,
            Func<TSecond, Unit> onSecond)
            =>
            ImplFold(onFirst, onSecond).Map(UnitToThis).OrDefault();

        public TaggedUnion<TFirst, TSecond> OnAny(
            Action<TFirst> onFirst,
            Action<TSecond> onSecond)
            =>
            ImplFold(onFirst.InvokeThenToUnit, onSecond.InvokeThenToUnit).Map(UnitToThis).OrDefault();

        public Task<Unit> OnAnyAsync(
            Func<TFirst, Task<Unit>> onFirstAsync,
            Func<TSecond, Task<Unit>> onSecondAsync)
            =>
            ImplFold(onFirstAsync, onSecondAsync).OrElse(() => Task.FromResult<Unit>(default));

        public Task OnAnyAsync(
            Func<TFirst, Task> onFirstAsync,
            Func<TSecond, Task> onSecondAsync)
            =>
            ImplFold(onFirstAsync, onSecondAsync).OrElse(() => Task.CompletedTask);

        public ValueTask<Unit> OnAnyAsync(
            Func<TFirst, ValueTask<Unit>> onFirstAsync,
            Func<TSecond, ValueTask<Unit>> onSecondAsync)
            =>
            ImplFold(onFirstAsync, onSecondAsync).OrElse(() => ValueTask.FromResult<Unit>(default));

        public ValueTask OnAnyAsync(
            Func<TFirst, ValueTask> onFirstAsync,
            Func<TSecond, ValueTask> onSecondAsync)
            =>
            ImplFold(onFirstAsync, onSecondAsync).OrElse(() => ValueTask.CompletedTask);

        // Non-Parameterized

        public TaggedUnion<TFirst, TSecond> OnAny(
            Func<Unit> onFirst,
            Func<Unit> onSecond)
            =>
            ImplFold(onFirst, onSecond).Map(UnitToThis).OrDefault();

        public TaggedUnion<TFirst, TSecond> OnAny(
            Action onFirst,
            Action onSecond)
            =>
            ImplFold(onFirst.InvokeThenToUnit, onSecond.InvokeThenToUnit).Map(UnitToThis).OrDefault();

        public Task<Unit> OnAnyAsync(
            Func<Task<Unit>> onFirstAsync,
            Func<Task<Unit>> onSecondAsync)
            =>
            ImplFold(onFirstAsync, onSecondAsync).OrElse(() => Task.FromResult<Unit>(default));

        public Task OnAnyAsync(
            Func<Task> onFirstAsync,
            Func<Task> onSecondAsync)
            =>
            ImplFold(onFirstAsync, onSecondAsync).OrElse(() => Task.CompletedTask);

        public ValueTask<Unit> OnAnyAsync(
            Func<ValueTask<Unit>> onFirstAsync,
            Func<ValueTask<Unit>> onSecondAsync)
            =>
            ImplFold(onFirstAsync, onSecondAsync).OrElse(() => ValueTask.FromResult<Unit>(default));

        public ValueTask OnAnyAsync(
            Func<ValueTask> onFirstAsync,
            Func<ValueTask> onSecondAsync)
            =>
            ImplFold(onFirstAsync, onSecondAsync).OrElse(() => ValueTask.CompletedTask);
    }
}
