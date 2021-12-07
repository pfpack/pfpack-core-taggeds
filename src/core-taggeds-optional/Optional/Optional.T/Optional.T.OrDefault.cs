namespace System;

partial struct Optional<T>
{
    public T? OrDefault()
        =>
        InnerOrDefault();
}
