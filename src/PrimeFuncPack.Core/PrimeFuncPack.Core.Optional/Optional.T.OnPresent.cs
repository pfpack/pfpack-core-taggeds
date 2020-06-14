#nullable enable

namespace System
{
    partial struct Optional<T>
    {
        public Unit OnPresent(in Func<T, Unit> func)
            =>
            box switch
            {
                null => default,
                var present => func.Invoke(present)
            };

        public Unit OnPresent(Action<T> action) => OnPresent(
            func: present =>
            {
                action.Invoke(present);
                return default;
            });

        public Unit OnPresent(in Func<Unit> func)
            =>
            box switch
            {
                null => default,
                _ => func.Invoke()
            };

        public Unit OnPresent(Action action) => OnPresent(
            func: () =>
            {
                action.Invoke();
                return default;
            });
    }
}
