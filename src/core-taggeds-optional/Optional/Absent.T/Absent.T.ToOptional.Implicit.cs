#pragma warning disable IDE0060 // Remove unused parameter

namespace System;

partial struct Absent<T>
{
    public static implicit operator Optional<T>(Absent<T> absent)
        =>
        default;
}
