#nullable enable

using System.Threading.Tasks;

namespace System
{
    partial struct Optional<T>
    {
        // Parameterized

        public Optional<T> OnPresent(in Func<T, Unit> func)
            =>
            InternalFold<Unit, Unit>(func, () => default).ToResult(this);

        public Optional<T> OnPresent(in Action<T> action)
            =>
            InternalFold<Unit, Unit>(action.InvokeToUnit, () => default).ToResult(this);

        public Task<Unit> OnPresentAsync(in Func<T, Task<Unit>> funcAsync)
            =>
            InternalFold<Unit, Task<Unit>>(funcAsync, () => Task.FromResult<Unit>(default));

        public Task OnPresentAsync(in Func<T, Task> funcAsync)
            =>
            InternalFold<Unit, Task>(funcAsync, () => Task.CompletedTask);

        public ValueTask<Unit> OnPresentAsync(in Func<T, ValueTask<Unit>> funcAsync)
            =>
            InternalFold<Unit, ValueTask<Unit>>(funcAsync, () => default);

        public ValueTask OnPresentAsync(in Func<T, ValueTask> funcAsync)
            =>
            InternalFold<Unit, ValueTask>(funcAsync, () => default);

        // Non-Parameterized

        public Optional<T> OnPresent(in Func<Unit> func)
            =>
            InternalFold<Unit, Unit>(func, () => default).ToResult(this);

        public Optional<T> OnPresent(in Action action)
            =>
            InternalFold<Unit, Unit>(action.InvokeToUnit, () => default).ToResult(this);

        public Task<Unit> OnPresentAsync(in Func<Task<Unit>> funcAsync)
            =>
            InternalFold<Unit, Task<Unit>>(funcAsync, () => Task.FromResult<Unit>(default));

        public Task OnPresentAsync(in Func<Task> funcAsync)
            =>
            InternalFold<Unit, Task>(funcAsync, () => Task.CompletedTask);

        public ValueTask<Unit> OnPresentAsync(in Func<ValueTask<Unit>> funcAsync)
            =>
            InternalFold<Unit, ValueTask<Unit>>(funcAsync, () => default);

        public ValueTask OnPresentAsync(in Func<ValueTask> funcAsync)
            =>
            InternalFold<Unit, ValueTask>(funcAsync, () => default);
    }
}
