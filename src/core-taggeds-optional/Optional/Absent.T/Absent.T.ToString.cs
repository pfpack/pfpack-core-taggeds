namespace System;

partial struct Absent<T>
{
    public override string ToString()
        =>
        InternalToString<T>.Absent();
}
