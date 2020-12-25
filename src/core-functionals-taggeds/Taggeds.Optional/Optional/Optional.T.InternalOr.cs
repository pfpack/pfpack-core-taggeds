#nullable enable

namespace System
{
    partial struct Optional<T>
    {
        private TResult InternalOr<TResult>(Func<Optional<T>, TResult> map, Func<TResult> otherFactory)
            =>
            InternalHandle(InternalThis, map, otherFactory);
    }
}
