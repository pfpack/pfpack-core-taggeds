#nullable enable

using System.Threading.Tasks;

namespace System
{
    partial struct Optional<T>
    {
        // Parameterized

        public Optional<T> OnPresentOrElse(in Func<T, Unit> func, in Func<Unit> elseFunc)
            =>
            ImplFold(func, elseFunc).ToResult(this);

        public Optional<T> OnPresentOrElse(Action<T> action, Action elseAction)
            =>
            ImplFold(action.InvokeToUnit, elseAction.InvokeToUnit).ToResult(this);

        public Task<Unit> OnPresentOrElseAsync(in Func<T, Task<Unit>> funcAsync, in Func<Task<Unit>> elseFuncAsync)
            =>
            ImplFold(funcAsync, elseFuncAsync);

        public Task OnPresentOrElseAsync(in Func<T, Task> funcAsync, in Func<Task> elseFuncAsync)
            =>
            ImplFold(funcAsync, elseFuncAsync);

        public ValueTask<Unit> OnPresentOrElseAsync(in Func<T, ValueTask<Unit>> funcAsync, in Func<ValueTask<Unit>> elseFuncAsync)
            =>
            ImplFold(funcAsync, elseFuncAsync);

        public ValueTask OnPresentOrElseAsync(in Func<T, ValueTask> funcAsync, in Func<ValueTask> elseFuncAsync)
            =>
            ImplFold(funcAsync, elseFuncAsync);

        // Non-Parameterized

        public Optional<T> OnPresentOrElse(in Func<Unit> func, in Func<Unit> elseFunc)
            =>
            ImplFold(func, elseFunc).ToResult(this);

        public Optional<T> OnPresentOrElse(Action action, Action elseAction)
            =>
            ImplFold(action.InvokeToUnit, elseAction.InvokeToUnit).ToResult(this);

        public Task<Unit> OnPresentOrElseAsync(in Func<Task<Unit>> funcAsync, in Func<Task<Unit>> elseFuncAsync)
            =>
            ImplFold(funcAsync, elseFuncAsync);

        public Task OnPresentOrElseAsync(in Func<Task> funcAsync, in Func<Task> elseFuncAsync)
            =>
            ImplFold(funcAsync, elseFuncAsync);

        public ValueTask<Unit> OnPresentOrElseAsync(in Func<ValueTask<Unit>> funcAsync, in Func<ValueTask<Unit>> elseFuncAsync)
            =>
            ImplFold(funcAsync, elseFuncAsync);

        public ValueTask OnPresentOrElseAsync(in Func<ValueTask> funcAsync, in Func<ValueTask> elseFuncAsync)
            =>
            ImplFold(funcAsync, elseFuncAsync);
    }
}
