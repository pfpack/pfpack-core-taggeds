using static System.FormattableString;

namespace System;

partial struct TaggedUnion<TFirst, TSecond>
{
    private static InvalidOperationException InnerCreateExpectedFirstException()
        =>
        new(InnerCreateExpectedTagMessage(InternalTag.First));

    private static InvalidOperationException InnerCreateExpectedSecondException()
        =>
        new(InnerCreateExpectedTagMessage(InternalTag.Second));

    private static string InnerCreateExpectedTagMessage(InternalTag tag)
        =>
        Invariant($"The tagged union is expected to represent the {tag} case.");
}
