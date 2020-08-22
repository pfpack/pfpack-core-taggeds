#nullable enable

using System.Threading.Tasks;

namespace System
{
    partial struct Optional<T>
    {
        // Parameterized

        public Optional<T> OnPresent(Func<T, Unit> func)
            =>
            ImplFold(func, () => default).ToResult(this);

        public Optional<T> OnPresent(Action<T> action)
            =>
            ImplFold(action.InvokeThenToUnit, () => default).ToResult(this);

        public Task<Unit> OnPresentAsync(Func<T, Task<Unit>> funcAsync)
            =>
            ImplFold(funcAsync, () => Task.FromResult<Unit>(default));

        public Task OnPresentAsync(Func<T, Task> funcAsync)
            =>
            ImplFold(funcAsync, () => Task.CompletedTask);

        public ValueTask<Unit> OnPresentAsync(Func<T, ValueTask<Unit>> funcAsync)
            =>
            ImplFold(funcAsync, () => default);

        public ValueTask OnPresentAsync(Func<T, ValueTask> funcAsync)
            =>
            ImplFold(funcAsync, () => default);

        // Non-Parameterized

        public Optional<T> OnPresent(Func<Unit> func)
            =>
            ImplFold(func, () => default).ToResult(this);

        public Optional<T> OnPresent(Action action)
            =>
            ImplFold(action.InvokeThenToUnit, () => default).ToResult(this);

        public Task<Unit> OnPresentAsync(Func<Task<Unit>> funcAsync)
            =>
            ImplFold(funcAsync, () => Task.FromResult<Unit>(default));

        public Task OnPresentAsync(Func<Task> funcAsync)
            =>
            ImplFold(funcAsync, () => Task.CompletedTask);

        public ValueTask<Unit> OnPresentAsync(Func<ValueTask<Unit>> funcAsync)
            =>
            ImplFold(funcAsync, () => default);

        public ValueTask OnPresentAsync(Func<ValueTask> funcAsync)
            =>
            ImplFold(funcAsync, () => default);
    }
}
