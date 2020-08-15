#nullable enable

using System.Threading.Tasks;

namespace System
{
    partial struct Optional<T>
    {
        // Parameterized

        public Optional<T> OnPresent(in Func<T, Unit> func)
            =>
            ImplFold(func, () => default).ToResult(this);

        public Optional<T> OnPresent(in Action<T> action)
            =>
            ImplFold(action.InvokeToUnit, () => default).ToResult(this);

        public Task<Unit> OnPresentAsync(in Func<T, Task<Unit>> funcAsync)
            =>
            ImplFold(funcAsync, () => Task.FromResult<Unit>(default));

        public Task OnPresentAsync(in Func<T, Task> funcAsync)
            =>
            ImplFold(funcAsync, () => Task.CompletedTask);

        public ValueTask<Unit> OnPresentAsync(in Func<T, ValueTask<Unit>> funcAsync)
            =>
            ImplFold(funcAsync, () => default);

        public ValueTask OnPresentAsync(in Func<T, ValueTask> funcAsync)
            =>
            ImplFold(funcAsync, () => default);

        // Non-Parameterized

        public Optional<T> OnPresent(in Func<Unit> func)
            =>
            ImplFold(func, () => default).ToResult(this);

        public Optional<T> OnPresent(in Action action)
            =>
            ImplFold(action.InvokeToUnit, () => default).ToResult(this);

        public Task<Unit> OnPresentAsync(in Func<Task<Unit>> funcAsync)
            =>
            ImplFold(funcAsync, () => Task.FromResult<Unit>(default));

        public Task OnPresentAsync(in Func<Task> funcAsync)
            =>
            ImplFold(funcAsync, () => Task.CompletedTask);

        public ValueTask<Unit> OnPresentAsync(in Func<ValueTask<Unit>> funcAsync)
            =>
            ImplFold(funcAsync, () => default);

        public ValueTask OnPresentAsync(in Func<ValueTask> funcAsync)
            =>
            ImplFold(funcAsync, () => default);
    }
}
