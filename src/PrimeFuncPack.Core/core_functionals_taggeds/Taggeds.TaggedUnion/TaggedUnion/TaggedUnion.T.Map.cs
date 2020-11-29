#nullable enable

using System.Threading.Tasks;

namespace System
{
    partial struct TaggedUnion<TFirst, TSecond>
    {
        public TaggedUnion<TResultFirst, TResultSecond> Map<TResultFirst, TResultSecond>(
            Func<TFirst, TResultFirst> mapFirst,
            Func<TSecond, TResultSecond> mapSecond)
        {
            _ = mapFirst ?? throw new ArgumentNullException(nameof(mapFirst));
            _ = mapSecond ?? throw new ArgumentNullException(nameof(mapSecond));

            return Fold<TaggedUnion<TResultFirst, TResultSecond>>(
                value => mapFirst.Invoke(value),
                value => mapSecond.Invoke(value),
                static () => default);
        }

        public Task<TaggedUnion<TResultFirst, TResultSecond>> MapAsync<TResultFirst, TResultSecond>(
            Func<TFirst, Task<TResultFirst>> mapFirstAsync,
            Func<TSecond, Task<TResultSecond>> mapSecondAsync)
        {
            _ = mapFirstAsync ?? throw new ArgumentNullException(nameof(mapFirstAsync));
            _ = mapSecondAsync ?? throw new ArgumentNullException(nameof(mapSecondAsync));

            return FoldAsync<TaggedUnion<TResultFirst, TResultSecond>>(
                async value => await mapFirstAsync.Invoke(value).ConfigureAwait(false),
                async value => await mapSecondAsync.Invoke(value).ConfigureAwait(false),
                () => Task.FromResult<TaggedUnion<TResultFirst, TResultSecond>>(default));
        }

        public ValueTask<TaggedUnion<TResultFirst, TResultSecond>> MapValueAsync<TResultFirst, TResultSecond>(
            Func<TFirst, ValueTask<TResultFirst>> mapFirstAsync,
            Func<TSecond, ValueTask<TResultSecond>> mapSecondAsync)
        {
            _ = mapFirstAsync ?? throw new ArgumentNullException(nameof(mapFirstAsync));
            _ = mapSecondAsync ?? throw new ArgumentNullException(nameof(mapSecondAsync));

            return FoldValueAsync<TaggedUnion<TResultFirst, TResultSecond>>(
                async value => await mapFirstAsync.Invoke(value).ConfigureAwait(false),
                async value => await mapSecondAsync.Invoke(value).ConfigureAwait(false),
                static () => default(ValueTask<TaggedUnion<TResultFirst, TResultSecond>>));
        }
    }
}
