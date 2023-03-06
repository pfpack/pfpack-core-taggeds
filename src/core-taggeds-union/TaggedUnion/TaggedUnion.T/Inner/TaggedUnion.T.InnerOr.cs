using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace System;

partial struct TaggedUnion<TFirst, TSecond>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private TaggedUnion<TFirst, TSecond> InnerOr(
        Func<TaggedUnion<TFirst, TSecond>> otherFactory)
        =>
        tag is not Tag.None ? this : otherFactory.Invoke();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private Task<TaggedUnion<TFirst, TSecond>> InnerOrAsync(
        Func<Task<TaggedUnion<TFirst, TSecond>>> otherFactoryAsync)
        =>
        tag is not Tag.None ? Task.FromResult(this) : otherFactoryAsync.Invoke();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private ValueTask<TaggedUnion<TFirst, TSecond>> InnerOrValueAsync(
        Func<ValueTask<TaggedUnion<TFirst, TSecond>>> otherFactoryAsync)
        =>
        tag is not Tag.None ? ValueTask.FromResult(this) : otherFactoryAsync.Invoke();
}
