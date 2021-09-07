#nullable enable

namespace System
{
    partial struct Optional<T>
    {
        public override string ToString()
            =>
            InnerFold(
                ToStringStrategy<T>.Present,
                ToStringStrategy<T>.Absent);
    }
}
