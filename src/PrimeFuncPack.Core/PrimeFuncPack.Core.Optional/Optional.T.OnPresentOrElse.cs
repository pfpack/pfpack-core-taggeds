#nullable enable

using System.Threading.Tasks;

namespace System
{
    partial struct Optional<T>
    {
        // Parameterized

        public Unit OnPresentOrElse(in Func<T, Unit> func, in Func<Unit> elseFunc)
            =>
            InternalOnPresentOrElse<Unit, Unit>(func, elseFunc);

        public Unit OnPresentOrElse(Action<T> action, Action elseAction)
            =>
            InternalOnPresentOrElse<Unit, Unit>(action.InvokeToUnit, elseAction.InvokeToUnit);

        public Task<Unit> OnPresentOrElseAsync(in Func<T, Task<Unit>> funcAsync, in Func<Task<Unit>> elseFuncAsync)
            =>
            InternalOnPresentOrElse<Unit, Task<Unit>>(funcAsync, elseFuncAsync);

        public Task OnPresentOrElseAsync(in Func<T, Task> funcAsync, in Func<Task> elseFuncAsync)
            =>
            InternalOnPresentOrElse<Unit, Task>(funcAsync, elseFuncAsync);

        public ValueTask<Unit> OnPresentOrElseAsync(in Func<T, ValueTask<Unit>> funcAsync, in Func<ValueTask<Unit>> elseFuncAsync)
            =>
            InternalOnPresentOrElse<Unit, ValueTask<Unit>>(funcAsync, elseFuncAsync);

        public ValueTask OnPresentOrElseAsync(in Func<T, ValueTask> funcAsync, in Func<ValueTask> elseFuncAsync)
            =>
            InternalOnPresentOrElse<Unit, ValueTask>(funcAsync, elseFuncAsync);

        // Non-Parameterized

        public Unit OnPresentOrElse(in Func<Unit> func, in Func<Unit> elseFunc)
            =>
            InternalOnPresentOrElse<Unit, Unit>(func, elseFunc);

        public Unit OnPresentOrElse(Action action, Action elseAction)
            =>
            InternalOnPresentOrElse<Unit, Unit>(action.InvokeToUnit, elseAction.InvokeToUnit);

        public Task<Unit> OnPresentOrElseAsync(in Func<Task<Unit>> funcAsync, in Func<Task<Unit>> elseFuncAsync)
            =>
            InternalOnPresentOrElse<Unit, Task<Unit>>(funcAsync, elseFuncAsync);

        public Task OnPresentOrElseAsync(in Func<Task> funcAsync, in Func<Task> elseFuncAsync)
            =>
            InternalOnPresentOrElse<Unit, Task>(funcAsync, elseFuncAsync);

        public ValueTask<Unit> OnPresentOrElseAsync(in Func<ValueTask<Unit>> funcAsync, in Func<ValueTask<Unit>> elseFuncAsync)
            =>
            InternalOnPresentOrElse<Unit, ValueTask<Unit>>(funcAsync, elseFuncAsync);

        public ValueTask OnPresentOrElseAsync(in Func<ValueTask> funcAsync, in Func<ValueTask> elseFuncAsync)
            =>
            InternalOnPresentOrElse<Unit, ValueTask>(funcAsync, elseFuncAsync);

        // Internal

        private TOuterResult InternalOnPresentOrElse<TResult, TOuterResult>(in Func<T, TOuterResult> func, in Func<TOuterResult> elseFunc)
        {
            if (func is null)
            {
                throw new ArgumentNullException(nameof(func));
            }

            if (elseFunc is null)
            {
                throw new ArgumentNullException(nameof(elseFunc));
            }

            return box switch
            {
                null => elseFunc.Invoke(),
                var present => func.Invoke(present)
            };
        }

        private TOuterResult InternalOnPresentOrElse<TResult, TOuterResult>(in Func<TOuterResult> func, in Func<TOuterResult> elseFunc)
        {
            if (func is null)
            {
                throw new ArgumentNullException(nameof(func));
            }

            if (elseFunc is null)
            {
                throw new ArgumentNullException(nameof(elseFunc));
            }

            return box switch
            {
                null => elseFunc.Invoke(),
                _ => func.Invoke()
            };
        }
    }
}
