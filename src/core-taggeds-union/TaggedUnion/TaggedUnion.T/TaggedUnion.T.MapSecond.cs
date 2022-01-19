using System.Threading.Tasks;

namespace System;

partial struct TaggedUnion<TFirst, TSecond>
{
    public TaggedUnion<TFirst, TResultSecond> MapSecond<TResultSecond>(
        Func<TSecond, TResultSecond> mapSecond)
        =>
        InnerMapSecond(
            mapSecond ?? throw new ArgumentNullException(nameof(mapSecond)));

    public Task<TaggedUnion<TFirst, TResultSecond>> MapSecondAsync<TResultSecond>(
        Func<TSecond, Task<TResultSecond>> mapSecondAsync)
        =>
        InnerMapSecondAsync(
            mapSecondAsync ?? throw new ArgumentNullException(nameof(mapSecondAsync)));

    public ValueTask<TaggedUnion<TFirst, TResultSecond>> MapSecondValueAsync<TResultSecond>(
        Func<TSecond, ValueTask<TResultSecond>> mapSecondAsync)
        =>
        InnerMapSecondValueAsync(
            mapSecondAsync ?? throw new ArgumentNullException(nameof(mapSecondAsync)));
}
