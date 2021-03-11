#nullable enable

namespace System
{
    partial struct Optional<T>
    {
        public override int GetHashCode()
            =>
            hasValue
                ? value is not null
                    ? HashCode.Combine(EqualityContract, true, EqualityComparer.GetHashCode(value))
                    : HashCode.Combine(EqualityContract, true)
                : HashCode.Combine(EqualityContract, false);
    }
}
