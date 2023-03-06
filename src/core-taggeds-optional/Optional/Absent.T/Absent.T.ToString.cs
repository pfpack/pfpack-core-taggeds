namespace System;

partial struct Absent<T>
{
    public override string ToString()
        =>
        $"Absent<{typeof(T).Name}>:()";
}
