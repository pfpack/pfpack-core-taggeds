#nullable enable

namespace System
{
    partial struct Optional<T>
    {
        public override int GetHashCode() => HashCode.Combine(
            typeof(Optional<T>),
            hasValue,
            ValueHashCodeOrDefault());

        private int ValueHashCodeOrDefault()
        {
            if (hasValue && value is not null)
            {
                return Equality.GetHashCode(value);
            }

            return default;
        }
    }
}
