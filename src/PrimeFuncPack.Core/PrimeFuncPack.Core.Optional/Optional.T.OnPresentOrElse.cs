#nullable enable

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
                func: present =>
                {
                    action.Invoke(present);
                    return default;
                },
                elseFunc: () =>
                {
                    elseAction.Invoke();
                    return default;
                });
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
                func: () =>
                {
                    action.Invoke();
                    return default;
                },
                elseFunc: () =>
                {
                    elseAction.Invoke();
                    return default;
                });
        }
    }
}
