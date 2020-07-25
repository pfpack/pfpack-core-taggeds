#nullable enable

namespace System
{
    partial struct TaggedUnion<TTag, TFirst, TSecond>
    {
        private TOuterResult InternalFold<TResult, TOuterResult>(
            Func<TFirst, TOuterResult> mapFirst,
            Func<TSecond, TOuterResult> mapSecond)
        {
            var @this = this;

            return default(Optional<TOuterResult>)
                .Or(() => @this.TryGetFirst().Map(mapFirst))
                .Or(() => @this.TryGetSecond().Map(mapSecond))
                .OrThrow(CreateNotInitializedException);
        }
    }
}
