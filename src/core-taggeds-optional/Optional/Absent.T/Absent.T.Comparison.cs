namespace System;

partial struct Absent<T>
{
    public int CompareTo(Absent<T> other) => default;

    public int CompareTo(object? obj) => obj switch
    {
        null => ComparisonResult.GreaterThan,

        Absent<T> => ComparisonResult.EqualTo,

        _ => throw new ArgumentException($"The object is not Absent<{typeof(T).Name}>.", nameof(obj))
    };
}
