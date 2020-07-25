#nullable enable

using System.Threading.Tasks;

namespace System
{
    partial struct Optional<T>
    {
        // Parameterized

        public Unit OnPresentOrElse(in Func<T, Unit> func, in Func<Unit> elseFunc)
            =>
            InternalFold<Unit, Unit>(func, elseFunc);

        public Unit OnPresentOrElse(Action<T> action, Action elseAction)
            =>
            InternalFold<Unit, Unit>(action.InvokeToUnit, elseAction.InvokeToUnit);

        public Task<Unit> OnPresentOrElseAsync(in Func<T, Task<Unit>> funcAsync, in Func<Task<Unit>> elseFuncAsync)
            =>
            InternalFold<Unit, Task<Unit>>(funcAsync, elseFuncAsync);

        public Task OnPresentOrElseAsync(in Func<T, Task> funcAsync, in Func<Task> elseFuncAsync)
            =>
            InternalFold<Unit, Task>(funcAsync, elseFuncAsync);

        public ValueTask<Unit> OnPresentOrElseAsync(in Func<T, ValueTask<Unit>> funcAsync, in Func<ValueTask<Unit>> elseFuncAsync)
            =>
            InternalFold<Unit, ValueTask<Unit>>(funcAsync, elseFuncAsync);

        public ValueTask OnPresentOrElseAsync(in Func<T, ValueTask> funcAsync, in Func<ValueTask> elseFuncAsync)
            =>
            InternalFold<Unit, ValueTask>(funcAsync, elseFuncAsync);

        // Non-Parameterized

        public Unit OnPresentOrElse(in Func<Unit> func, in Func<Unit> elseFunc)
            =>
            InternalFold<Unit, Unit>(func, elseFunc);

        public Unit OnPresentOrElse(Action action, Action elseAction)
            =>
            InternalFold<Unit, Unit>(action.InvokeToUnit, elseAction.InvokeToUnit);

        public Task<Unit> OnPresentOrElseAsync(in Func<Task<Unit>> funcAsync, in Func<Task<Unit>> elseFuncAsync)
            =>
            InternalFold<Unit, Task<Unit>>(funcAsync, elseFuncAsync);

        public Task OnPresentOrElseAsync(in Func<Task> funcAsync, in Func<Task> elseFuncAsync)
            =>
            InternalFold<Unit, Task>(funcAsync, elseFuncAsync);

        public ValueTask<Unit> OnPresentOrElseAsync(in Func<ValueTask<Unit>> funcAsync, in Func<ValueTask<Unit>> elseFuncAsync)
            =>
            InternalFold<Unit, ValueTask<Unit>>(funcAsync, elseFuncAsync);

        public ValueTask OnPresentOrElseAsync(in Func<ValueTask> funcAsync, in Func<ValueTask> elseFuncAsync)
            =>
            InternalFold<Unit, ValueTask>(funcAsync, elseFuncAsync);
    }
}
