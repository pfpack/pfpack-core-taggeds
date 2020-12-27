#nullable enable

namespace System
{
    partial struct TaggedUnion<TFirst, TSecond>
    {
        private TResult InternalFold<TResult>(
            Func<TFirst, TResult> mapFirst,
            Func<TSecond, TResult> mapSecond,
            Func<TResult> otherFactory)
        {
            var @this = this;

            return default(Optional<TResult>)
                .Or(() => @this.first.Map(mapFirst))
                .Or(() => @this.second.Map(mapSecond))
                .OrElse(otherFactory);
        }
    }
}
