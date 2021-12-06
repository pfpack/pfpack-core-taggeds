namespace System;

partial class Optional
{
    public static Optional<T> Present<T>(T value)
        =>
        new(value);

    public static Optional<T> Absent<T>()
        =>
        default;

#pragma warning disable IDE0060 // Remove unused parameter
    public static Optional<T> Absent<T>(Unit unit)
#pragma warning restore IDE0060 // Remove unused parameter
        =>
        default;
}
