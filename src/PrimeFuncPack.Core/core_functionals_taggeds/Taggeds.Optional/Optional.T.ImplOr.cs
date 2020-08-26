#nullable enable

namespace System
{
    partial struct Optional<T>
    {
        private TResult ImplOr<TResult>(in Func<Optional<T>, TResult> map, in Func<TResult> otherFactory)
        {
            _ = map ?? throw new ArgumentNullException(nameof(map));
            _ = otherFactory ?? throw new ArgumentNullException(nameof(otherFactory));

            return box switch
            {
                not null => map.Invoke(this),
                _ => otherFactory.Invoke()
            };
        }
    }
}
