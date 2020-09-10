#nullable enable

using System.Threading.Tasks;

namespace System
{
    partial struct TaggedUnion<TFirst, TSecond>
    {
        private TaggedUnion<TResultFirst, TResultSecond> ImplMap<TResultFirst, TResultSecond>(
            Func<TFirst, TResultFirst> mapFirst,
            Func<TSecond, TResultSecond> mapSecond)
        {
            _ = mapFirst ?? throw new ArgumentNullException(nameof(mapFirst));
            _ = mapSecond ?? throw new ArgumentNullException(nameof(mapSecond));

            return Fold<TaggedUnion<TResultFirst, TResultSecond>>(
                value => mapFirst.Invoke(value),
                value => mapSecond.Invoke(value),
                () => default);
        }

        private Task<TaggedUnion<TResultFirst, TResultSecond>> ImplMapAsync<TResultFirst, TResultSecond>(
            Func<TFirst, Task<TResultFirst>> mapFirstAsync,
            Func<TSecond, Task<TResultSecond>> mapSecondAsync)
        {
            _ = mapFirstAsync ?? throw new ArgumentNullException(nameof(mapFirstAsync));
            _ = mapSecondAsync ?? throw new ArgumentNullException(nameof(mapSecondAsync));

            return FoldAsync(
                async value => (TaggedUnion<TResultFirst, TResultSecond>)await mapFirstAsync.Invoke(value).ConfigureAwait(false),
                async value => (TaggedUnion<TResultFirst, TResultSecond>)await mapSecondAsync.Invoke(value).ConfigureAwait(false),
                () => default);
        }

        private ValueTask<TaggedUnion<TResultFirst, TResultSecond>> ImplMapValueAsync<TResultFirst, TResultSecond>(
            Func<TFirst, ValueTask<TResultFirst>> mapFirstAsync,
            Func<TSecond, ValueTask<TResultSecond>> mapSecondAsync)
        {
            _ = mapFirstAsync ?? throw new ArgumentNullException(nameof(mapFirstAsync));
            _ = mapSecondAsync ?? throw new ArgumentNullException(nameof(mapSecondAsync));

            return FoldValueAsync(
                async value => (TaggedUnion<TResultFirst, TResultSecond>)await mapFirstAsync.Invoke(value).ConfigureAwait(false),
                async value => (TaggedUnion<TResultFirst, TResultSecond>)await mapSecondAsync.Invoke(value).ConfigureAwait(false),
                () => default);
        }
    }
}
