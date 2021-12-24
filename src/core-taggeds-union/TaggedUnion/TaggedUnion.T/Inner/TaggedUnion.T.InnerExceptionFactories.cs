namespace System;

partial struct TaggedUnion<TFirst, TSecond>
{
    private static InvalidOperationException InnerCreateExpectedFirstException()
        =>
        InnerCreateExpectedCategoryException("First");

    private static InvalidOperationException InnerCreateExpectedSecondException()
        =>
        InnerCreateExpectedCategoryException("Second");

    private static InvalidOperationException InnerCreateExpectedCategoryException(string category)
        =>
        new($"The tagged union is expected to represent a {category} instance.");
}
