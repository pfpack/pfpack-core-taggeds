#nullable enable

namespace System
{
    partial struct Optional<T>
    {
        private TResult InternalOr<TResult>(in Func<Optional<T>, TResult> map, in Func<TResult> otherFactory)
            =>
            box switch
            {
                not null => map.Invoke(this),
                _ => otherFactory.Invoke()
            };
    }
}
