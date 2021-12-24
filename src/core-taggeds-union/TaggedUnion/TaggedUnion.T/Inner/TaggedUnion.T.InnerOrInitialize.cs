using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace System;

partial struct TaggedUnion<TFirst, TSecond>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private TaggedUnion<TFirst, TSecond> InnerOrInitialize(
        Func<TaggedUnion<TFirst, TSecond>> otherFactory)
        =>
        tag != default ? this : otherFactory.Invoke();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private Task<TaggedUnion<TFirst, TSecond>> InnerOrInitializeAsync(
        Func<Task<TaggedUnion<TFirst, TSecond>>> otherFactoryAsync)
        =>
        tag != default ? Task.FromResult(this) : otherFactoryAsync.Invoke();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private ValueTask<TaggedUnion<TFirst, TSecond>> InnerOrInitializeValueAsync(
        Func<ValueTask<TaggedUnion<TFirst, TSecond>>> otherFactoryAsync)
        =>
        tag != default ? ValueTask.FromResult(this) : otherFactoryAsync.Invoke();
}
