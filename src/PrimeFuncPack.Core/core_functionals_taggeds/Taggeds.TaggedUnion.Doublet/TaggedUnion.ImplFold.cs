#nullable enable

namespace System
{
    partial struct TaggedUnion<TFirst, TSecond>
    {
        private Optional<TResult> ImplFold<TResult>(
            Func<TFirst, TResult> mapFirst,
            Func<TSecond, TResult> mapSecond)
        {
            _ = mapFirst ?? throw new ArgumentNullException(nameof(mapFirst));
            _ = mapSecond ?? throw new ArgumentNullException(nameof(mapSecond));

            var @this = this;

            return default(Optional<TResult>)
                .Or(() => @this.First().Map(mapFirst))
                .Or(() => @this.Second().Map(mapSecond));
        }
    }
}
