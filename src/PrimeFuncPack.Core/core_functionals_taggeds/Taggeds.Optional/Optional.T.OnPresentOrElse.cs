#nullable enable

using System.Threading.Tasks;

namespace System
{
    partial struct Optional<T>
    {
        // Parameterized

        public Optional<T> OnPresentOrElse(Func<T, Unit> func, Func<Unit> elseFunc)
            =>
            ImplFold(func, elseFunc).ToResult(this);

        public Optional<T> OnPresentOrElse(Action<T> action, Action elseAction)
            =>
            ImplFold(action.InvokeToUnit, elseAction.InvokeToUnit).ToResult(this);

        public Task<Unit> OnPresentOrElseAsync(Func<T, Task<Unit>> funcAsync, Func<Task<Unit>> elseFuncAsync)
            =>
            ImplFold(funcAsync, elseFuncAsync);

        public Task OnPresentOrElseAsync(Func<T, Task> funcAsync, Func<Task> elseFuncAsync)
            =>
            ImplFold(funcAsync, elseFuncAsync);

        public ValueTask<Unit> OnPresentOrElseAsync(Func<T, ValueTask<Unit>> funcAsync, Func<ValueTask<Unit>> elseFuncAsync)
            =>
            ImplFold(funcAsync, elseFuncAsync);

        public ValueTask OnPresentOrElseAsync(Func<T, ValueTask> funcAsync, Func<ValueTask> elseFuncAsync)
            =>
            ImplFold(funcAsync, elseFuncAsync);

        // Non-Parameterized

        public Optional<T> OnPresentOrElse(Func<Unit> func, Func<Unit> elseFunc)
            =>
            ImplFold(func, elseFunc).ToResult(this);

        public Optional<T> OnPresentOrElse(Action action, Action elseAction)
            =>
            ImplFold(action.InvokeToUnit, elseAction.InvokeToUnit).ToResult(this);

        public Task<Unit> OnPresentOrElseAsync(Func<Task<Unit>> funcAsync, Func<Task<Unit>> elseFuncAsync)
            =>
            ImplFold(funcAsync, elseFuncAsync);

        public Task OnPresentOrElseAsync(Func<Task> funcAsync, Func<Task> elseFuncAsync)
            =>
            ImplFold(funcAsync, elseFuncAsync);

        public ValueTask<Unit> OnPresentOrElseAsync(Func<ValueTask<Unit>> funcAsync, Func<ValueTask<Unit>> elseFuncAsync)
            =>
            ImplFold(funcAsync, elseFuncAsync);

        public ValueTask OnPresentOrElseAsync(Func<ValueTask> funcAsync, Func<ValueTask> elseFuncAsync)
            =>
            ImplFold(funcAsync, elseFuncAsync);
    }
}
