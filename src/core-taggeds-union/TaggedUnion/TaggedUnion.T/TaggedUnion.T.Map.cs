using System.Threading.Tasks;

namespace System;

partial struct TaggedUnion<TFirst, TSecond>
{
    public TaggedUnion<TResultFirst, TResultSecond> Map<TResultFirst, TResultSecond>(
        Func<TFirst, TResultFirst> mapFirst,
        Func<TSecond, TResultSecond> mapSecond)
        =>
        InnerMap(
            mapFirst ?? throw new ArgumentNullException(nameof(mapFirst)),
            mapSecond ?? throw new ArgumentNullException(nameof(mapSecond)));

    public Task<TaggedUnion<TResultFirst, TResultSecond>> MapAsync<TResultFirst, TResultSecond>(
        Func<TFirst, Task<TResultFirst>> mapFirstAsync,
        Func<TSecond, Task<TResultSecond>> mapSecondAsync)
        =>
        InnerMapAsync(
            mapFirstAsync ?? throw new ArgumentNullException(nameof(mapFirstAsync)),
            mapSecondAsync ?? throw new ArgumentNullException(nameof(mapSecondAsync)));

    public ValueTask<TaggedUnion<TResultFirst, TResultSecond>> MapValueAsync<TResultFirst, TResultSecond>(
        Func<TFirst, ValueTask<TResultFirst>> mapFirstAsync,
        Func<TSecond, ValueTask<TResultSecond>> mapSecondAsync)
        =>
        InnerMapValueAsync(
            mapFirstAsync ?? throw new ArgumentNullException(nameof(mapFirstAsync)),
            mapSecondAsync ?? throw new ArgumentNullException(nameof(mapSecondAsync)));
}
