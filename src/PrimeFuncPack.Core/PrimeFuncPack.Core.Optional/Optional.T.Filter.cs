#nullable enable

namespace System
{
    partial struct Optional<T>
    {
        public Optional<T> Filter(in Func<T, bool> predicate)
            =>
            box switch
            {
                null => default,
                var present when predicate.Invoke(present) => this,
                _ => default
            };
    }
}
