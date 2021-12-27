namespace System;

partial struct Absent<T>
{
    public static readonly Absent<T> Value;

    // TODO: Remove the static constructor when Absent<T> becomes public (it is a workaround for the internal Absent<T>)
    static Absent() => Value = default;
}
