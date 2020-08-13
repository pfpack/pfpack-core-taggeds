#nullable enable

namespace System
{
    partial struct TaggedUnion<TFirst, TSecond>
    {
        private TResult ImplFoldOrThrow<TResult>(
            in Func<TFirst, TResult> onFirst,
            in Func<TSecond, TResult> onSecond)
            =>
            ImplFold(onFirst, onSecond).OrThrow(CreateNotInitializedException);

        private TResult ImplFoldOrElse<TResult>(
            in Func<TFirst, TResult> onFirst,
            in Func<TSecond, TResult> onSecond,
            in TResult other)
            =>
            ImplFold(onFirst, onSecond).OrElse(other);

        private TResult ImplFoldOrElse<TResult>(
            in Func<TFirst, TResult> onFirst,
            in Func<TSecond, TResult> onSecond,
            in Func<TResult> otherFactory)
        {
            _ = otherFactory ?? throw new ArgumentNullException(nameof(otherFactory));

            return ImplFold(onFirst, onSecond).OrElse(otherFactory);
        }

        private Optional<TResult> ImplFold<TResult>(
            Func<TFirst, TResult> onFirst,
            Func<TSecond, TResult> onSecond)
        {
            _ = onFirst ?? throw new ArgumentNullException(nameof(onFirst));
            _ = onSecond ?? throw new ArgumentNullException(nameof(onSecond));

            var @this = this;

            return default(Optional<TResult>)
                .Or(() => @this.First().Map(onFirst))
                .Or(() => @this.Second().Map(onSecond));
        }
    }
}
