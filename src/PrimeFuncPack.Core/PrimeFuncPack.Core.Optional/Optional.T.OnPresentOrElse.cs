#nullable enable

using System.Threading.Tasks;

namespace System
{
    partial struct Optional<T>
    {
        public Unit OnPresentOrElse(in Func<T, Unit> func, in Func<Unit> elseFunc)
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

        public Unit OnPresentOrElse(Action<T> action, Action elseAction)
        {
            if (action is null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            if (elseAction is null)
            {
                throw new ArgumentNullException(nameof(elseAction));
            }

            return OnPresentOrElse(
                func: present => action.InvokeToUnit(present),
                elseFunc: () => elseAction.InvokeToUnit());
        }

        public Unit OnPresentOrElse(in Func<Unit> func, in Func<Unit> elseFunc)
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

        public Unit OnPresentOrElse(Action action, Action elseAction)
        {
            if (action is null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            if (elseAction is null)
            {
                throw new ArgumentNullException(nameof(elseAction));
            }

            return OnPresentOrElse(
                func: () => action.InvokeToUnit(),
                elseFunc: () => elseAction.InvokeToUnit());
        }

        public Task<Unit> OnPresentOrElseAsync(in Func<T, Task<Unit>> funcAsync, in Func<Task<Unit>> elseFuncAsync)
        {
            if (funcAsync is null)
            {
                throw new ArgumentNullException(nameof(funcAsync));
            }

            if (elseFuncAsync is null)
            {
                throw new ArgumentNullException(nameof(elseFuncAsync));
            }

            return box switch
            {
                null => elseFuncAsync.Invoke(),
                var present => funcAsync.Invoke(present)
            };
        }

        public Task<Unit> OnPresentOrElseAsync(in Func<Task<Unit>> funcAsync, in Func<Task<Unit>> elseFuncAsync)
        {
            if (funcAsync is null)
            {
                throw new ArgumentNullException(nameof(funcAsync));
            }

            if (elseFuncAsync is null)
            {
                throw new ArgumentNullException(nameof(elseFuncAsync));
            }

            return box switch
            {
                null => elseFuncAsync.Invoke(),
                _ => funcAsync.Invoke()
            };
        }
    }
}
