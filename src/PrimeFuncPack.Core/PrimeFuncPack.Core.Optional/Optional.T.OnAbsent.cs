#nullable enable

namespace System
{
    partial struct Optional<T>
    {
        public Unit OnAbsent(in Func<Unit> func)
            =>
            box switch
            {
                null => func.Invoke(),
                _ => default
            };

        public Unit OnAbsent(Action action) => OnAbsent(
            func: () =>
            {
                action.Invoke();
                return default;
            });
    }
}
