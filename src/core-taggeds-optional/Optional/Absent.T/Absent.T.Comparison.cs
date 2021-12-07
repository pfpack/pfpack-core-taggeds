namespace System;
using static System.FormattableString;

partial struct Absent<T>
{
    public int CompareTo(Absent<T> other) => default;

    public int CompareTo(object? obj) => obj switch
    {
        null => 1,

        Absent<T> => default,

        _ => throw new ArgumentException(Invariant($"The object is not Absent[{typeof(T)}]."), nameof(obj))
    };
}
