#nullable enable

namespace System
{
    partial struct Optional<T>
    {
        private TResult InternalFold<TResult>(Func<T, TResult> map, Func<TResult> otherFactory)
            =>
            box switch
            {
                not null => map.Invoke(box.Value),
                _ => otherFactory.Invoke()
            };
    }
}
