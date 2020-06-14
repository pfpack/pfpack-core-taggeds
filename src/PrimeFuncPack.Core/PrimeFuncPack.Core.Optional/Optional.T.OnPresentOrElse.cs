#nullable enable

namespace System
{
    partial struct Optional<T>
    {
        public Unit OnPresentOrElse(in Func<T, Unit> func, in Func<Unit> elseFunc)
            =>
            box switch
            {
                null => elseFunc.Invoke(),
                var present => func.Invoke(present)
            };

        public Unit OnPresentOrElse(Action<T> action, Action elseAction) => OnPresentOrElse(
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

        public Unit OnPresentOrElse(in Func<Unit> func, in Func<Unit> elseFunc)
            =>
            box switch
            {
                null => elseFunc.Invoke(),
                _ => func.Invoke()
            };

        public Unit OnPresentOrElse(Action action, Action elseAction) => OnPresentOrElse(
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
