using System.Threading.Tasks;

namespace System;

// TODO: Consider to remove the class in v3.0 or v4.0
[Obsolete(InnerClassObsoleteMessage, error: true)]
public static class TaggedUnionExtensions
{
    private const string InnerClassObsoleteMessage
        =
        "This class is obsolete. Use TaggedUnion instance methods instead.";

    private const string InnerOrInitializeMethodObsoleteMessage
        =
        "This method is obsolete. Call TaggedUnion Or instance method instead.";

    private const string InnerOrInitializeAsyncMethodObsoleteMessage
        =
        "This method is obsolete. Call TaggedUnion OrAsync instance method instead.";

    private const string InnerOrInitializeValueAsyncMethodObsoleteMessage
        =
        "This method is obsolete. Call TaggedUnion OrValueAsync instance method instead.";

    [Obsolete(InnerOrInitializeMethodObsoleteMessage, error: true)]
    public static TaggedUnion<TFirst, TSecond> OrInitialize<TFirst, TSecond>(
        TaggedUnion<TFirst, TSecond> union,
        Func<TaggedUnion<TFirst, TSecond>> otherFactory)
        =>
        union.Or(
            otherFactory ?? throw new ArgumentNullException(nameof(otherFactory)));

    [Obsolete(InnerOrInitializeAsyncMethodObsoleteMessage, error: true)]
    public static Task<TaggedUnion<TFirst, TSecond>> OrInitializeAsync<TFirst, TSecond>(
        TaggedUnion<TFirst, TSecond> union,
        Func<Task<TaggedUnion<TFirst, TSecond>>> otherFactoryAsync)
        =>
        union.OrAsync(
            otherFactoryAsync ?? throw new ArgumentNullException(nameof(otherFactoryAsync)));

    [Obsolete(InnerOrInitializeValueAsyncMethodObsoleteMessage, error: true)]
    public static ValueTask<TaggedUnion<TFirst, TSecond>> OrInitializeValueAsync<TFirst, TSecond>(
        TaggedUnion<TFirst, TSecond> union,
        Func<ValueTask<TaggedUnion<TFirst, TSecond>>> otherFactoryAsync)
        =>
        union.OrValueAsync(
            otherFactoryAsync ?? throw new ArgumentNullException(nameof(otherFactoryAsync)));
}
