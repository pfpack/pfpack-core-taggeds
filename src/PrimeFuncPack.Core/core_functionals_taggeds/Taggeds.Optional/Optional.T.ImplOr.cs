#nullable enable

namespace System
{
    partial struct Optional<T>
    {
        private TResult ImplOr<TResult>(in Func<Optional<T>, TResult> mapThis, in Func<TResult> otherFactory)
        {
            _ = mapThis ?? throw new ArgumentNullException(nameof(mapThis));
            _ = otherFactory ?? throw new ArgumentNullException(nameof(otherFactory));

            return box switch
            {
                not null => mapThis.Invoke(this),
                _ => otherFactory.Invoke()
            };
        }
    }
}
