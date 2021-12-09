namespace System;

partial struct Optional<T>
{
    public override string ToString()
        =>
        InnerFold(
            InternalToString<T>.OptionalPresent,
            InternalToString<T>.OptionalAbsent);
}
