#nullable enable

namespace System
{
    partial struct Present<T>
    {
        public static Present<T> From(T value)
            =>
            new(value);
    }
}
