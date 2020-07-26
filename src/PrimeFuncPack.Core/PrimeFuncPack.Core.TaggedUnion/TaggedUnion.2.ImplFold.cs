#nullable enable

namespace System
{
    partial struct TaggedUnion<TFirst, TSecond>
    {
        private TResult ImplFold<TResult>(
            Func<TFirst, TResult> mapFirst,
            Func<TSecond, TResult> mapSecond)
        {
            if (mapFirst is null)
            {
                throw new ArgumentNullException(nameof(mapFirst));
            }

            if (mapSecond is null)
            {
                throw new ArgumentNullException(nameof(mapSecond));
            }

            var @this = this;

            return default(Optional<TResult>)
                .Or(() => @this.TryGetFirst().Map(mapFirst))
                .Or(() => @this.TryGetSecond().Map(mapSecond))
                .OrThrow(CreateNotInitializedException);
        }
    }
}
