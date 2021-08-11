#nullable enable

namespace System
{
    partial struct Optional<T>
    {
        public override string ToString()
            =>
            InternalFold(
                ToStringStrategies<T>.Present,
                ToStringStrategies<T>.Absent);
    }
}
