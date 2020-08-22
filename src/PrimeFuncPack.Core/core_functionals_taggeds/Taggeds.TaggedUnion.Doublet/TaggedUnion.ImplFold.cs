#nullable enable

namespace System
{
    partial struct TaggedUnion<TFirst, TSecond>
    {
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

        private TResult ImplFold<TResult>(
            in Func<TaggedUnion<TFirst, TSecond>, TResult> onAny,
            in Func<TResult> onDefault)
        {
            _ = onAny ?? throw new ArgumentNullException(nameof(onAny));
            _ = onDefault ?? throw new ArgumentNullException(nameof(onDefault));

            return IsInitialized switch
            {
                true => onAny.Invoke(this),
                _ => onDefault.Invoke()
            };
        }
    }
}
