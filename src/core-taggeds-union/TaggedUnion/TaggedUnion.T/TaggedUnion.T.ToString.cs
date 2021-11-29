namespace System;

partial struct TaggedUnion<TFirst, TSecond>
{
    // TODO: For v1.2: Implement the ToString in according to Optional/Unit v1.2
    public override string ToString()
        =>
        InternalFold(
            value => value?.ToString() ?? string.Empty,
            value => value?.ToString() ?? string.Empty,
            () => string.Empty);
}
