#nullable enable

using System.Threading.Tasks;

namespace System
{
    partial struct TaggedUnion<TFirst, TSecond>
    {
        // Parameterized

        public TaggedUnion<TFirst, TSecond> OnSecond(
            Func<TSecond, Unit> onSecond)
            =>
            ImplFold(_ => default, onSecond).Map(UnitToThis).OrDefault();

        public TaggedUnion<TFirst, TSecond> OnSecond(
            Action<TSecond> onSecond)
            =>
            ImplFold(_ => default, onSecond.InvokeThenToUnit).Map(UnitToThis).OrDefault();

        public Task<Unit> OnSecondAsync(
            Func<TSecond, Task<Unit>> onSecondAsync)
            =>
            ImplFold(_ => Task.FromResult<Unit>(default), onSecondAsync).OrElse(() => Task.FromResult<Unit>(default));

        public Task OnSecondAsync(
            Func<TSecond, Task> onSecondAsync)
            =>
            ImplFold(_ => Task.CompletedTask, onSecondAsync).OrElse(() => Task.CompletedTask);

        public ValueTask<Unit> OnSecondAsync(
            Func<TSecond, ValueTask<Unit>> onSecondAsync)
            =>
            ImplFold(_ => ValueTask.FromResult<Unit>(default), onSecondAsync).OrElse(() => ValueTask.FromResult<Unit>(default));

        public ValueTask OnSecondAsync(
            Func<TSecond, ValueTask> onSecondAsync)
            =>
            ImplFold(_ => ValueTask.CompletedTask, onSecondAsync).OrElse(() => ValueTask.CompletedTask);

        // Non-Parameterized

        public TaggedUnion<TFirst, TSecond> OnSecond(
            Func<Unit> onSecond)
            =>
            ImplFold(() => default, onSecond).Map(UnitToThis).OrDefault();

        public TaggedUnion<TFirst, TSecond> OnSecond(
            Action onSecond)
            =>
            ImplFold(() => default, onSecond.InvokeThenToUnit).Map(UnitToThis).OrDefault();

        public Task<Unit> OnSecondAsync(
            Func<Task<Unit>> onSecondAsync)
            =>
            ImplFold(() => Task.FromResult<Unit>(default), onSecondAsync).OrElse(() => Task.FromResult<Unit>(default));

        public Task OnSecondAsync(
            Func<Task> onSecondAsync)
            =>
            ImplFold(() => Task.CompletedTask, onSecondAsync).OrElse(() => Task.CompletedTask);

        public ValueTask<Unit> OnSecondAsync(
            Func<ValueTask<Unit>> onSecondAsync)
            =>
            ImplFold(() => ValueTask.FromResult<Unit>(default), onSecondAsync).OrElse(() => ValueTask.FromResult<Unit>(default));

        public ValueTask OnSecondAsync(
            Func<ValueTask> onSecondAsync)
            =>
            ImplFold(() => ValueTask.CompletedTask, onSecondAsync).OrElse(() => ValueTask.CompletedTask);
    }
}
