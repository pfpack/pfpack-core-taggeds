#nullable enable

namespace System
{
    partial struct Absent<T>
    {
        public override string ToString()
            =>
            ToStringStrategies<T>.Absent();
    }
}
