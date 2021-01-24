#nullable enable

namespace System
{
    partial struct Optional<T>
    {
        public override int GetHashCode() => HashCode.Combine(
            typeof(Optional<T>),
            hasValue,
            HashCodeOrDefault());

        private int HashCodeOrDefault()
        {
            if (hasValue && value is not null)
            {
                return Equality.GetHashCode(value);
            }

            return default;
        }
    }
}
