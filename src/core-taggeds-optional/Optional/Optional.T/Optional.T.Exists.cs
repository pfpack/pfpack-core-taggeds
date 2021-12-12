namespace System;

partial struct Optional<T>
{
    // TODO: Add the tests and open the method
    internal bool Exists(Func<T, bool> predicate)
        =>
        InnerExists(predicate);
}
