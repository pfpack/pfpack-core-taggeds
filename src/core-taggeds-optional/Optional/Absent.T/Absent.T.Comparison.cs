namespace System;

partial struct Absent<T>
{
    public int CompareTo(Absent<T> other) => default;
}
