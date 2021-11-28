namespace System;

partial class Absent
{
    public static bool Equals<T>(Absent<T> left, Absent<T> right) => (left, right) switch
    {
        _ => true
    };
}
