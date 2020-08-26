#nullable enable

namespace System
{
    partial struct Optional<T>
    {
        public Optional<T> Filter(Func<T, bool> predicate)
        {
            _ = predicate ?? throw new ArgumentNullException(nameof(predicate));

            var @this = this;

            return ImplFold(Filter, () => @this);

            Optional<T> Filter(T value) => predicate(value) switch
            {
                true => @this,
                _ => default
            };
        }
    }
}
