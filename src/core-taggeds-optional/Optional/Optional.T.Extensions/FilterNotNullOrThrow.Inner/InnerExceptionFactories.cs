namespace System;

partial class OptionalExtensions
{
    private static InvalidOperationException InnerCreateExpectedNotNullException()
        =>
        new("The value is expected to be not null.");
}
