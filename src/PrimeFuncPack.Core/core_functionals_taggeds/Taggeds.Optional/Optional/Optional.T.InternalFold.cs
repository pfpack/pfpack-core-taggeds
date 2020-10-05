#nullable enable

namespace System
{
    partial struct Optional<T>
    {
        private TResult InternalFold<TResult>(in Func<T, TResult> map, in Func<TResult> otherFactory)
            =>
            box switch
            {
                not null => map.Invoke(box),
                _ => otherFactory.Invoke()
            };
    }
}
