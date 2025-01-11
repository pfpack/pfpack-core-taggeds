namespace System;

partial struct Optional<T>
{
    public T? OrDefault()
        =>
        value;
}
