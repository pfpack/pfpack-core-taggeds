using System.Threading.Tasks;

namespace System;

partial class TaggedUnionExtensions
{
    public static TaggedUnion<TFirst, TSecond> OrInitialize<TFirst, TSecond>(
        this TaggedUnion<TFirst, TSecond> union,
        Func<TaggedUnion<TFirst, TSecond>> otherFactory)
    {
        _ = otherFactory ?? throw new ArgumentNullException(nameof(otherFactory));

        return union.InternalOrInitialize(Pipeline.Pipe, otherFactory);
    }

    public static Task<TaggedUnion<TFirst, TSecond>> OrInitializeAsync<TFirst, TSecond>(
        this TaggedUnion<TFirst, TSecond> union,
        Func<Task<TaggedUnion<TFirst, TSecond>>> otherFactoryAsync)
    {
        _ = otherFactoryAsync ?? throw new ArgumentNullException(nameof(otherFactoryAsync));

        return union.InternalOrInitialize(Task.FromResult, otherFactoryAsync);
    }

    public static ValueTask<TaggedUnion<TFirst, TSecond>> OrInitializeValueAsync<TFirst, TSecond>(
        this TaggedUnion<TFirst, TSecond> union,
        Func<ValueTask<TaggedUnion<TFirst, TSecond>>> otherFactoryAsync)
    {
        _ = otherFactoryAsync ?? throw new ArgumentNullException(nameof(otherFactoryAsync));

        return union.InternalOrInitialize(ValueTask.FromResult, otherFactoryAsync);
    }
}
