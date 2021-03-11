#nullable enable

namespace System
{
    partial struct Optional<T>
    {
        public override int GetHashCode()
        {
            if (hasValue)
            {
                return value is not null
                    ? HashCode.Combine(EqualityContract, true, EqualityComparer.GetHashCode(value))
                    : HashCode.Combine(EqualityContract, true);
            }

            return HashCode.Combine(EqualityContract, false);
        }
    }
}
