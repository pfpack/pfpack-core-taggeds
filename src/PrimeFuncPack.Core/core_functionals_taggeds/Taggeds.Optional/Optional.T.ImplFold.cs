#nullable enable

namespace System
{
    partial struct Optional<T>
    {
        private TResult ImplFold<TResult>(in Func<T, TResult> map, in Func<TResult> otherFactory)
        {
            _ = map ?? throw new ArgumentNullException(nameof(map));
            _ = otherFactory ?? throw new ArgumentNullException(nameof(otherFactory));

            return box switch
            {
                not null => map.Invoke(box),
                _ => otherFactory.Invoke()
            };
        }
    }
}
