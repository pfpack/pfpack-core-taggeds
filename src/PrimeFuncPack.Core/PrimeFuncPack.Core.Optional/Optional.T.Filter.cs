#nullable enable

namespace System
{
    partial struct Optional<T>
    {
        public Optional<T> Filter(in Func<T, bool> predicate)
        {
            _ = predicate ?? throw new ArgumentNullException(nameof(predicate));

            var @this = this;
            var thePredicate = predicate;

            return ImplFold(Filter, This);

            Optional<T> Filter(T value) => thePredicate(value) switch
            {
                true => @this,
                _ => default
            };
        }
    }
}
