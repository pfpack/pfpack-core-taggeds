#nullable enable

namespace System
{
    partial struct Optional<T>
    {
        public override int GetHashCode() => hasValue switch
        {
            true =>
            HashCode.Combine(EqualityContract, true, HashCodeOrDefault()),
            _ =>
            HashCode.Combine(EqualityContract, false)
        };

        private int HashCodeOrDefault() => value switch
        {
            not null => EqualityComparer.GetHashCode(value),
            _ => default
        };
    }
}
