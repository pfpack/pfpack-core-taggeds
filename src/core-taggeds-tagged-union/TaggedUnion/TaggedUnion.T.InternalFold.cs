#nullable enable

using static System.Optional;

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

            return Absent<TResult>()
                .Or(() => @this.first.Map(mapFirst))
                .Or(() => @this.second.Map(mapSecond))
                .OrElse(otherFactory);
        }
    }
}
