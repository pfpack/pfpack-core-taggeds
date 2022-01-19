#pragma warning disable CA1822 // Mark members as static

namespace System;

partial struct Absent<T>
{
    public Optional<T> ToOptional()
        =>
        default;
}
