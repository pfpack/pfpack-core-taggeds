#nullable enable

using System.Threading.Tasks;

namespace System
{
    partial struct TaggedUnion<TFirst, TSecond>
    {
        public TaggedUnion<TResultFirst, TSecond> MapFirst<TResultFirst>(
            Func<TFirst, TResultFirst> mapFirst)
        {
            _ = mapFirst ?? throw new ArgumentNullException(nameof(mapFirst));

            return Fold<TaggedUnion<TResultFirst, TSecond>>(
                value => mapFirst.Invoke(value),
                static value => value,
                static () => default);
        }

        public Task<TaggedUnion<TResultFirst, TSecond>> MapFirstAsync<TResultFirst>(
            Func<TFirst, Task<TResultFirst>> mapFirstAsync)
        {
            _ = mapFirstAsync ?? throw new ArgumentNullException(nameof(mapFirstAsync));

            return FoldAsync<TaggedUnion<TResultFirst, TSecond>>(
                async value => await mapFirstAsync.Invoke(value).ConfigureAwait(false),
                static value => Task.FromResult<TaggedUnion<TResultFirst, TSecond>>(value),
                static () => Task.FromResult<TaggedUnion<TResultFirst, TSecond>>(default));
        }

        public ValueTask<TaggedUnion<TResultFirst, TSecond>> MapFirstValueAsync<TResultFirst>(
            Func<TFirst, ValueTask<TResultFirst>> mapFirstAsync)
        {
            _ = mapFirstAsync ?? throw new ArgumentNullException(nameof(mapFirstAsync));

            return FoldValueAsync<TaggedUnion<TResultFirst, TSecond>>(
                async value => await mapFirstAsync.Invoke(value).ConfigureAwait(false),
                static value => ValueTask.FromResult<TaggedUnion<TResultFirst, TSecond>>(value),
                static () => default(ValueTask<TaggedUnion<TResultFirst, TSecond>>));
        }
    }
}
