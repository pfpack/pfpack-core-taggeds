#nullable enable

namespace System
{
    partial struct Optional<T>
    {
        public override string ToString()
            =>
            InnerFold(
                InternalToStringStrategy<T>.Present,
                InternalToStringStrategy<T>.Absent);
    }
}
