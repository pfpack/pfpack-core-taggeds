#nullable enable

using System.Threading.Tasks;

namespace System
{
    partial struct Optional<T>
    {
        public Optional<T> OnAbsent(Func<Unit> func)
            =>
            ImplFold(func, () => default).ToResult(this);

        public Optional<T> OnAbsent(Action action)
            =>
            ImplFold(action.InvokeToUnit, () => default).ToResult(this);

        public Task<Unit> OnAbsentAsync(Func<Task<Unit>> funcAsync)
            =>
            ImplFold(funcAsync, () => Task.FromResult<Unit>(default));

        public Task OnAbsentAsync(Func<Task> funcAsync)
            =>
            ImplFold(funcAsync, () => Task.CompletedTask);

        public ValueTask<Unit> OnAbsentAsync(Func<ValueTask<Unit>> funcAsync)
            =>
            ImplFold(funcAsync, () => default);

        public ValueTask OnAbsentAsync(Func<ValueTask> funcAsync)
            =>
            ImplFold(funcAsync, () => default);
    }
}
