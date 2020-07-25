#nullable enable

using System.Threading.Tasks;

namespace System
{
    partial struct Optional<T>
    {
        public Unit OnAbsent(in Func<Unit> func)
            =>
            InternalFold<Unit, Unit>(func, () => default);

        public Unit OnAbsent(in Action action)
            =>
            InternalFold<Unit, Unit>(action.InvokeToUnit, () => default);

        public Task<Unit> OnAbsentAsync(in Func<Task<Unit>> funcAsync)
            =>
            InternalFold<Unit, Task<Unit>>(funcAsync, () => Task.FromResult<Unit>(default));

        public Task OnAbsentAsync(in Func<Task> funcAsync)
            =>
            InternalFold<Unit, Task>(funcAsync, () => Task.CompletedTask);

        public ValueTask<Unit> OnAbsentAsync(in Func<ValueTask<Unit>> funcAsync)
            =>
            InternalFold<Unit, ValueTask<Unit>>(funcAsync, () => default);

        public ValueTask OnAbsentAsync(in Func<ValueTask> funcAsync)
            =>
            InternalFold<Unit, ValueTask>(funcAsync, () => default);
    }
}
