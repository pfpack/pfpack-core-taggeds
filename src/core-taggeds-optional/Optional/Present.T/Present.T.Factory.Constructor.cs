#pragma warning disable IDE0290 // Use primary constructor

namespace System;

partial struct Present<T>
{
    public Present(T value)
        =>
        this.value = value;
}
