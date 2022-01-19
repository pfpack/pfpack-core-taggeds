namespace System;

partial struct Optional<T>
{
    public override string ToString()
        =>
        InnerToString();
}
