#nullable enable

namespace System
{
    partial struct Optional<T>
    {
        private TResult InternalOr<TResult>(Func<Optional<T>, TResult> map, Func<TResult> otherFactory)
            =>
            hasValue switch
            {
                true => map.Invoke(this),
                _ => otherFactory.Invoke()
            };
    }
}
