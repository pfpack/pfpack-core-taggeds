#nullable enable

using System.Threading.Tasks;

namespace System
{
    partial struct TaggedUnion<TTag, TFirst, TSecond>
    {
        public TTag Fold() => Fold<TTag>(
            value => value,
            value => value);

        public TResult Fold<TResult>(
            in Func<TFirst, TResult> mapFirst,
            in Func<TSecond, TResult> mapSecond)
            =>
            InternalFold<TResult, TResult>(mapFirst, mapSecond);

        public Task<TResult> FoldAsync<TResult>(
            in Func<TFirst, Task<TResult>> mapFirst,
            in Func<TSecond, Task<TResult>> mapSecond)
            =>
            InternalFold<TResult, Task<TResult>>(mapFirst, mapSecond);

        public ValueTask<TResult> FoldAsync<TResult>(
            in Func<TFirst, ValueTask<TResult>> mapFirst,
            in Func<TSecond, ValueTask<TResult>> mapSecond)
            =>
            InternalFold<TResult, ValueTask<TResult>>(mapFirst, mapSecond);

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
