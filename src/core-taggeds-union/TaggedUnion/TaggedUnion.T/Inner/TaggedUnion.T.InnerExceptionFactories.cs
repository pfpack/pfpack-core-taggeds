using static System.FormattableString;

namespace System;

partial struct TaggedUnion<TFirst, TSecond>
{
    private static InvalidOperationException InnerCreateExpectedFirstException()
        =>
        new(InnerCreateExpectedTagMessage(Tag.First));

    private static InvalidOperationException InnerCreateExpectedSecondException()
        =>
        new(InnerCreateExpectedTagMessage(Tag.Second));

    private static string InnerCreateExpectedTagMessage(Tag tag)
        =>
        Invariant($"The tagged union is expected to represent the {tag} case.");
}
