using System.Threading.Tasks;

namespace System;

partial struct TaggedUnion<TFirst, TSecond>
{
    public TaggedUnion<TFirst, TSecond> Or(
        Func<TaggedUnion<TFirst, TSecond>> otherFactory)
        =>
        InnerOr(
            otherFactory ?? throw new ArgumentNullException(nameof(otherFactory)));

    public Task<TaggedUnion<TFirst, TSecond>> OrAsync(
        Func<Task<TaggedUnion<TFirst, TSecond>>> otherFactoryAsync)
        =>
        InnerOrAsync(
            otherFactoryAsync ?? throw new ArgumentNullException(nameof(otherFactoryAsync)));

    public ValueTask<TaggedUnion<TFirst, TSecond>> OrValueAsync(
        Func<ValueTask<TaggedUnion<TFirst, TSecond>>> otherFactoryAsync)
        =>
        InnerOrValueAsync(
            otherFactoryAsync ?? throw new ArgumentNullException(nameof(otherFactoryAsync)));
}
