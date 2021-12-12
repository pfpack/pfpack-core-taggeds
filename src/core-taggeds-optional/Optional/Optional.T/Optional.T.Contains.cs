namespace System;

partial struct Optional<T>
{
    // TODO: Add the tests and open the method
    internal bool Contains(T value)
        =>
        InnerContains(value);
}
