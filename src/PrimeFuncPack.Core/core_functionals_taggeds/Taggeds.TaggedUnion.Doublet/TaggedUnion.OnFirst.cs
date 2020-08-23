#nullable enable

using System.Threading.Tasks;

namespace System
{
    partial struct TaggedUnion<TFirst, TSecond>
    {
        // Parameterized

        public TaggedUnion<TFirst, TSecond> OnFirst(
            Func<TFirst, Unit> onFirst)
            =>
            ImplFold(onFirst, _ => default).Map(UnitToThis).OrDefault();

        public TaggedUnion<TFirst, TSecond> OnFirst(
            Action<TFirst> onFirst)
            =>
            ImplFold(onFirst.InvokeThenToUnit, _ => default).Map(UnitToThis).OrDefault();

        public Task<Unit> OnFirstAsync(
            Func<TFirst, Task<Unit>> onFirstAsync)
            =>
            ImplFold(onFirstAsync, _ => Task.FromResult<Unit>(default)).OrElse(() => Task.FromResult<Unit>(default));

        public Task OnFirstAsync(
            Func<TFirst, Task> onFirstAsync)
            =>
            ImplFold(onFirstAsync, _ => Task.CompletedTask).OrElse(() => Task.CompletedTask);

        public ValueTask<Unit> OnFirstAsync(
            Func<TFirst, ValueTask<Unit>> onFirstAsync)
            =>
            ImplFold(onFirstAsync, _ => ValueTask.FromResult<Unit>(default)).OrElse(() => ValueTask.FromResult<Unit>(default));

        public ValueTask OnFirstAsync(
            Func<TFirst, ValueTask> onFirstAsync)
            =>
            ImplFold(onFirstAsync, _ => ValueTask.CompletedTask).OrElse(() => ValueTask.CompletedTask);

        // Non-Parameterized

        public TaggedUnion<TFirst, TSecond> OnFirst(
            Func<Unit> onFirst)
            =>
            ImplFold(onFirst, () => default).Map(UnitToThis).OrDefault();

        public TaggedUnion<TFirst, TSecond> OnFirst(
            Action onFirst)
            =>
            ImplFold(onFirst.InvokeThenToUnit, () => default).Map(UnitToThis).OrDefault();

        public Task<Unit> OnFirstAsync(
            Func<Task<Unit>> onFirstAsync)
            =>
            ImplFold(onFirstAsync, () => Task.FromResult<Unit>(default)).OrElse(() => Task.FromResult<Unit>(default));

        public Task OnFirstAsync(
            Func<Task> onFirstAsync)
            =>
            ImplFold(onFirstAsync, () => Task.CompletedTask).OrElse(() => Task.CompletedTask);

        public ValueTask<Unit> OnFirstAsync(
            Func<ValueTask<Unit>> onFirstAsync)
            =>
            ImplFold(onFirstAsync, () => ValueTask.FromResult<Unit>(default)).OrElse(() => ValueTask.FromResult<Unit>(default));

        public ValueTask OnFirstAsync(
            Func<ValueTask> onFirstAsync)
            =>
            ImplFold(onFirstAsync, () => ValueTask.CompletedTask).OrElse(() => ValueTask.CompletedTask);
    }
}
