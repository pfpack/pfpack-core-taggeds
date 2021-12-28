namespace System;

partial class Optional
{
    public static Optional<T> PresentOrThrow<T>(T? value)
        =>
        value is not null
            ? new(value)
            : throw InnerCreateExpectedSpecifiedException(nameof(value));

    public static Optional<T> PresentOrThrow<T>(T? value)
        where T : struct
        =>
        value is not null
            ? new(value.GetValueOrDefault())
            : throw InnerCreateExpectedSpecifiedException(nameof(value));

    private static ArgumentException InnerCreateExpectedSpecifiedException(string paramName)
        =>
        new("The value is expected to be specified.", paramName);
}
