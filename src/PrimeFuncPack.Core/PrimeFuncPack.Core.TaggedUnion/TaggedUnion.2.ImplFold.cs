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

            var This = this;

            return default(Optional<TResult>)
                .Or(() => This.TryGetFirst().Map(mapFirst))
                .Or(() => This.TryGetSecond().Map(mapSecond))
                .OrThrow(CreateNotInitializedException);
        }
    }
}
