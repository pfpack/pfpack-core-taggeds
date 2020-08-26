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
    }
}
