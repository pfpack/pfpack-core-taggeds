#nullable enable

using System.Threading.Tasks;

namespace System
{
    partial struct TaggedUnion<TFirst, TSecond>
    {
        public TaggedUnion<TFirst, TResultSecond> MapSecond<TResultSecond>(
            Func<TSecond, TResultSecond> mapSecond)
        {
            _ = mapSecond ?? throw new ArgumentNullException(nameof(mapSecond));

            return Fold<TaggedUnion<TFirst, TResultSecond>>(
                static value => value,
                value => mapSecond.Invoke(value),
                static () => default);
        }

        public Task<TaggedUnion<TFirst, TResultSecond>> MapSecondAsync<TResultSecond>(
            Func<TSecond, Task<TResultSecond>> mapSecondAsync)
        {
            _ = mapSecondAsync ?? throw new ArgumentNullException(nameof(mapSecondAsync));

            return FoldAsync<TaggedUnion<TFirst, TResultSecond>>(
                static value => Task.FromResult<TaggedUnion<TFirst, TResultSecond>>(value),
                async value => await mapSecondAsync.Invoke(value).ConfigureAwait(false),
                static () => Task.FromResult<TaggedUnion<TFirst, TResultSecond>>(default));
        }

        public ValueTask<TaggedUnion<TFirst, TResultSecond>> MapSecondValueAsync<TResultSecond>(
            Func<TSecond, ValueTask<TResultSecond>> mapSecondAsync)
        {
            _ = mapSecondAsync ?? throw new ArgumentNullException(nameof(mapSecondAsync));

            return FoldValueAsync<TaggedUnion<TFirst, TResultSecond>>(
                static value => ValueTask.FromResult<TaggedUnion<TFirst, TResultSecond>>(value),
                async value => await mapSecondAsync.Invoke(value).ConfigureAwait(false),
                static () => default(ValueTask<TaggedUnion<TFirst, TResultSecond>>));
        }
    }
}
