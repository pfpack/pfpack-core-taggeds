#nullable enable

namespace System
{
    partial struct Optional<T>
    {
        public Optional<T> Filter(in Func<T, bool> predicate)
            =>
            IsPresent switch
            {
                true when predicate.Invoke(Value) => this,
                _ => default
            };
    }
}
