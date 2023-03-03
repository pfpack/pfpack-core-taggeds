namespace System;

partial struct Optional<T>
{
    public bool Equals(Optional<T> other)
    {
        if (hasValue != other.hasValue)
        {
            return false;
        }

        if (hasValue)
        {
            return ValueEqualityComparer.Equals(value, other.value);
        }

        return true;
    }
}
