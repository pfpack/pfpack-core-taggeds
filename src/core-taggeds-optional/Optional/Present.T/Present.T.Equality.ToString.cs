#nullable enable

namespace System
{
    partial struct Present<T>
    {
        public override string ToString()
            =>
            value.ToStringOrEmpty();
    }
}
