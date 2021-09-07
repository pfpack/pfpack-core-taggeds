#nullable enable

namespace System
{
    partial struct Absent<T>
    {
        public override string ToString()
            =>
            InternalToStringStrategy<T>.Absent();
    }
}
