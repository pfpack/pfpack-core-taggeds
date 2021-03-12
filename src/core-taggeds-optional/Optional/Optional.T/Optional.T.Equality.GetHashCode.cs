#nullable enable

namespace System
{
    partial struct Optional<T>
    {
        public override int GetHashCode()
            =>
            hasValue && value is not null
                ? HashCode.Combine(typeof(Optional<T>), hasValue, EqualityComparer.GetHashCode(value))
                : HashCode.Combine(typeof(Optional<T>), hasValue);
    }
}
