#nullable enable

namespace System
{
    partial struct Present<T>
    {
        public static implicit operator Present<T>(T value)
            =>
            new(value);
    }
}
