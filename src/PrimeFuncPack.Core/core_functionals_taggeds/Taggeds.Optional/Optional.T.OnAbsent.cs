#nullable enable

using System.Threading.Tasks;

namespace System
{
    partial struct Optional<T>
    {
        public Optional<T> OnAbsent(in Func<Unit> func)
            =>
            ImplFold(func, () => default).ToResult(this);

        public Optional<T> OnAbsent(in Action action)
            =>
            ImplFold(action.InvokeToUnit, () => default).ToResult(this);

        public Task<Unit> OnAbsentAsync(in Func<Task<Unit>> funcAsync)
            =>
            ImplFold(funcAsync, () => Task.FromResult<Unit>(default));

        public Task OnAbsentAsync(in Func<Task> funcAsync)
            =>
            ImplFold(funcAsync, () => Task.CompletedTask);

        public ValueTask<Unit> OnAbsentAsync(in Func<ValueTask<Unit>> funcAsync)
            =>
            ImplFold(funcAsync, () => default);

        public ValueTask OnAbsentAsync(in Func<ValueTask> funcAsync)
            =>
            ImplFold(funcAsync, () => default);
    }
}
