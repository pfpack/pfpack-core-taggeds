#nullable enable

namespace System
{
    partial struct Optional<T>
    {
        public static readonly Optional<T> Absent;

        public static Optional<T> Present(T value)
            =>
            new(value);
    }
}
