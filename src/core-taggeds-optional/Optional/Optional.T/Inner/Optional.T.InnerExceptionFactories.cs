namespace System
{
    partial struct Optional<T>
    {
        private static InvalidOperationException InnerCreateExpectedPresentException()
            =>
            new("The optional is expected to have a value.");
    }
}
