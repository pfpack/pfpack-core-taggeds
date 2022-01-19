using System.Threading.Tasks;

namespace System;

partial struct TaggedUnion<TFirst, TSecond>
{
    public TaggedUnion<TResultFirst, TSecond> MapFirst<TResultFirst>(
        Func<TFirst, TResultFirst> mapFirst)
        =>
        InnerMapFirst(
            mapFirst ?? throw new ArgumentNullException(nameof(mapFirst)));

    public Task<TaggedUnion<TResultFirst, TSecond>> MapFirstAsync<TResultFirst>(
        Func<TFirst, Task<TResultFirst>> mapFirstAsync)
        =>
        InnerMapFirstAsync(
            mapFirstAsync ?? throw new ArgumentNullException(nameof(mapFirstAsync)));

    public ValueTask<TaggedUnion<TResultFirst, TSecond>> MapFirstValueAsync<TResultFirst>(
        Func<TFirst, ValueTask<TResultFirst>> mapFirstAsync)
        =>
        InnerMapFirstValueAsync(
            mapFirstAsync ?? throw new ArgumentNullException(nameof(mapFirstAsync)));
}
