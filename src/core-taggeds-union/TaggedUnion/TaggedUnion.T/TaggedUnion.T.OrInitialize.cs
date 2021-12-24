using System.Threading.Tasks;

namespace System;

partial struct TaggedUnion<TFirst, TSecond>
{
    public TaggedUnion<TFirst, TSecond> OrInitialize(
        Func<TaggedUnion<TFirst, TSecond>> otherFactory)
        =>
        InnerOrInitialize(
            otherFactory ?? throw new ArgumentNullException(nameof(otherFactory)));

    public Task<TaggedUnion<TFirst, TSecond>> OrInitializeAsync(
        Func<Task<TaggedUnion<TFirst, TSecond>>> otherFactoryAsync)
        =>
        InnerOrInitializeAsync(
            otherFactoryAsync ?? throw new ArgumentNullException(nameof(otherFactoryAsync)));

    public ValueTask<TaggedUnion<TFirst, TSecond>> OrInitializeValueAsync(
        Func<ValueTask<TaggedUnion<TFirst, TSecond>>> otherFactoryAsync)
        =>
        InnerOrInitializeValueAsync(
            otherFactoryAsync ?? throw new ArgumentNullException(nameof(otherFactoryAsync)));
}
