#nullable enable

namespace System
{
    partial struct Optional<T>
    {
        public bool Equals(Optional<T> other)
            =>
            (hasValue == other.hasValue) &&
            (hasValue
                ? EqualityComparer.Equals(value, other.value)
                : true);
        // {
        //     if (hasValue != other.hasValue)
        //     {
        //         return false;
        //     }

        //     if (hasValue)
        //     {
        //         return EqualityComparer.Equals(value, other.value);
        //     }

        //     return true;
        // }
    }
}
