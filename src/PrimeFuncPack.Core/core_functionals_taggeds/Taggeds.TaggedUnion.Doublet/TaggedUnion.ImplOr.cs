#nullable enable

namespace System
{
    partial struct TaggedUnion<TFirst, TSecond>
    {
        private TResult ImplOr<TResult>(
            in Func<TaggedUnion<TFirst, TSecond>, TResult> map,
            in Func<TResult> otherFactory)
        {
            _ = map ?? throw new ArgumentNullException(nameof(map));
            _ = otherFactory ?? throw new ArgumentNullException(nameof(otherFactory));

            return IsInitialized switch
            {
                true => map.Invoke(this),
                _ => otherFactory.Invoke()
            };
        }
    }
}
