#pragma warning disable IDE0060 // Remove unused parameter

namespace System;

partial class Absent
{
    public static bool Equals<T>(Absent<T> left, Absent<T> right)
        =>
        true;
}
