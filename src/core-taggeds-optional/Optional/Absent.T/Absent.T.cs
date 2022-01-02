namespace System;

// TODO: Add the tests and open the type
internal readonly partial struct Absent<T> :
    IComparable,
    IComparable<Absent<T>>,
    IEquatable<Absent<T>>
{
}
