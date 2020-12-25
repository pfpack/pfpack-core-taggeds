#nullable enable

namespace System
{
    partial struct Optional<T>
    {
        public override int GetHashCode() => HashCode.Combine(
            typeof(Optional<T>),
            hasValue,
            ValueHashCodeOrDefault());

        private int ValueHashCodeOrDefault() => hasValue switch
        {
            true => ValueHashCode(),
            _ => default
        };

        private int ValueHashCode() => value switch
        {
            not null => ValueEquality.GetHashCode(value),
            _ => default
        };
    }
}
