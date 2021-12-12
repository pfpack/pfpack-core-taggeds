namespace System;

partial class OptionalExtensions
{
    private static Optional<T> InnerFlattenPipe<T>(Optional<T> optional) => optional;
}
