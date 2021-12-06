namespace System;

partial struct Absent<T>
{
    public bool Equals(Absent<T> other)
        =>
        true;

    public override bool Equals(object? obj)
        =>
        obj is Absent<T>;

    public override int GetHashCode()
        =>
        HashCode.Combine(typeof(Absent<T>));
}
