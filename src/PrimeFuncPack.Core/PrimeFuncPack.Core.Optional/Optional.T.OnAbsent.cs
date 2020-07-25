#nullable enable

using System.Threading.Tasks;

namespace System
{
    partial struct Optional<T>
    {
        public Unit OnAbsent(in Func<Unit> func)
            =>
            InternalOnAbsent<Unit, Unit>(func, () => default);

        public Unit OnAbsent(in Action action)
            =>
            InternalOnAbsent<Unit, Unit>(action.InvokeToUnit, () => default);

        public Task<Unit> OnAbsentAsync(in Func<Task<Unit>> funcAsync)
            =>
            InternalOnAbsent<Unit, Task<Unit>>(funcAsync, () => Task.FromResult<Unit>(default));

        public Task OnAbsentAsync(in Func<Task> funcAsync)
            =>
            InternalOnAbsent<Unit, Task>(funcAsync, () => Task.CompletedTask);

        public ValueTask<Unit> OnAbsentAsync(in Func<ValueTask<Unit>> funcAsync)
            =>
            InternalOnAbsent<Unit, ValueTask<Unit>>(funcAsync, () => default);

        public ValueTask OnAbsentAsync(in Func<ValueTask> funcAsync)
            =>
            InternalOnAbsent<Unit, ValueTask>(funcAsync, () => default);

        private TOuterResult InternalOnAbsent<TResult, TOuterResult>(in Func<TOuterResult> func, in Func<TOuterResult> defaultOuterFactory)
            =>
            InternalOnPresentOrElse<TResult, TOuterResult>(defaultOuterFactory, func);
    }
}
