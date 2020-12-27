#nullable enable

namespace System
{
    partial struct Optional<T>
    {
        private TResult InternalFold<TResult>(Func<T, TResult> map, Func<TResult> otherFactory)
            =>
            InternalHandle(Value, map, otherFactory);
    }
}
