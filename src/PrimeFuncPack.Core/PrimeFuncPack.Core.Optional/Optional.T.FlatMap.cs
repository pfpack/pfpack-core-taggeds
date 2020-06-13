#nullable enable

namespace System
{
    partial struct Optional<T>
    {
        public Optional<TResult> FlatMap<TResult>(in Func<T, Optional<TResult>> map)
            =>
            IsPresent switch
            {
                true => map.Invoke(Value),
                _ => default
            };
    }
}
