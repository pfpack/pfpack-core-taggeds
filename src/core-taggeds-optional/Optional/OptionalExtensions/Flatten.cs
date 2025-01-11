namespace System;

partial class OptionalExtensions
{
    // TODO: Add the tests and open the method
    internal static Optional<T> Flatten<T>(Optional<Optional<T>> optional)
        =>
        optional.Bind(innerOptional => innerOptional);
}
