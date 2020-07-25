#nullable enable

using System.Threading.Tasks;

namespace System
{
    partial struct Optional<T>
    {
        // Parameterized

        public Unit OnPresent(in Func<T, Unit> func)
            =>
            InternalOnPresent<Unit, Unit>(func, () => default);

        public Unit OnPresent(in Action<T> action)
            =>
            InternalOnPresent<Unit, Unit>(action.InvokeToUnit, () => default);

        public Task<Unit> OnPresentAsync(in Func<T, Task<Unit>> funcAsync)
            =>
            InternalOnPresent<Unit, Task<Unit>>(funcAsync, () => Task.FromResult<Unit>(default));

        public Task OnPresentAsync(in Func<T, Task> funcAsync)
            =>
            InternalOnPresent<Unit, Task>(funcAsync, () => Task.CompletedTask);

        public ValueTask<Unit> OnPresentAsync(in Func<T, ValueTask<Unit>> funcAsync)
            =>
            InternalOnPresent<Unit, ValueTask<Unit>>(funcAsync, () => default);

        public ValueTask OnPresentAsync(in Func<T, ValueTask> funcAsync)
            =>
            InternalOnPresent<Unit, ValueTask>(funcAsync, () => default);

        // Non-Parameterized

        public Unit OnPresent(in Func<Unit> func)
            =>
            InternalOnPresent<Unit, Unit>(func, () => default);

        public Unit OnPresent(in Action action)
            =>
            InternalOnPresent<Unit, Unit>(action.InvokeToUnit, () => default);

        public Task<Unit> OnPresentAsync(in Func<Task<Unit>> funcAsync)
            =>
            InternalOnPresent<Unit, Task<Unit>>(funcAsync, () => Task.FromResult<Unit>(default));

        public Task OnPresentAsync(in Func<Task> funcAsync)
            =>
            InternalOnPresent<Unit, Task>(funcAsync, () => Task.CompletedTask);

        public ValueTask<Unit> OnPresentAsync(in Func<ValueTask<Unit>> funcAsync)
            =>
            InternalOnPresent<Unit, ValueTask<Unit>>(funcAsync, () => default);

        public ValueTask OnPresentAsync(in Func<ValueTask> funcAsync)
            =>
            InternalOnPresent<Unit, ValueTask>(funcAsync, () => default);

        private TOuterResult InternalOnPresent<TResult, TOuterResult>(in Func<T, TOuterResult> func, in Func<TOuterResult> defaultOuterFactory)
            =>
            InternalOnPresentOrElse<TResult, TOuterResult>(func, defaultOuterFactory);

        private TOuterResult InternalOnPresent<TResult, TOuterResult>(in Func<TOuterResult> func, in Func<TOuterResult> defaultOuterFactory)
            =>
            InternalOnPresentOrElse<TResult, TOuterResult>(func, defaultOuterFactory);
    }
}
