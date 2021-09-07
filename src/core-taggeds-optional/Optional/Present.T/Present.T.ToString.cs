#nullable enable

namespace System
{
    partial struct Present<T>
    {
        public override string ToString()
            =>
            InternalToStringStrategy<T>.Present(value);
    }
}
