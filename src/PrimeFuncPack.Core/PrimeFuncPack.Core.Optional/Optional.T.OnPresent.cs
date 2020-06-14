#nullable enable

namespace System
{
    partial struct Optional<T>
    {
        public Unit OnPresent(in Func<T, Unit> func)
        {
            if (func is null)
            {
                throw new ArgumentNullException(nameof(func));
            }

            return box switch
            {
                null => default,
                var present => func.Invoke(present)
            };
        }

        public Unit OnPresent(Action<T> action)
        {
            if (action is null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            return OnPresent(func: present => action.InvokeToUnit(present));
        }

        public Unit OnPresent(in Func<Unit> func)
        {
            if (func is null)
            {
                throw new ArgumentNullException(nameof(func));
            }

            return box switch
            {
                null => default,
                _ => func.Invoke()
            };
        }

        public Unit OnPresent(Action action)
        {
            if (action is null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            return OnPresent(func: () => action.InvokeToUnit());
        }
    }
}
