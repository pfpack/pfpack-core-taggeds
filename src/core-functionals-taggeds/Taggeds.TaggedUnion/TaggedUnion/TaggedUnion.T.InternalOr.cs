#nullable enable

namespace System
{
    partial struct TaggedUnion<TFirst, TSecond>
    {
        private TResult InternalOr<TResult>(
            in Func<TaggedUnion<TFirst, TSecond>, TResult> map,
            in Func<TResult> otherFactory)
            =>
            IsInitialized switch
            {
                true => map.Invoke(this),
                _ => otherFactory.Invoke()
            };
    }
}
