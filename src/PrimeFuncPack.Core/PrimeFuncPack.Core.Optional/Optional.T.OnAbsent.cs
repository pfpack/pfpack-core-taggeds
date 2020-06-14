#nullable enable

namespace System
{
    partial struct Optional<T>
    {
        public Unit OnAbsent(in Func<Unit> func)
        {
            if (func is null)
            {
                throw new ArgumentNullException(nameof(func));
            }

            return box switch
            {
                null => func.Invoke(),
                _ => default
            };
        }

        public Unit OnAbsent(Action action)
        {
            if (action is null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            return OnAbsent(
                func: () =>
                {
                    action.Invoke();
                    return default;
                });
        }
    }
}
