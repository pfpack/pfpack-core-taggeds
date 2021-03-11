#nullable enable

namespace System
{
    partial struct Optional<T>
    {
        public override int GetHashCode()
            =>
            hasValue
                ? HashCode.Combine(EqualityContract, true, HashCodeOrDefault())
                : HashCode.Combine(EqualityContract, false);

        private int HashCodeOrDefault()
            =>
            value is not null
                ? EqualityComparer.GetHashCode(value)
                : default;
    }
}
