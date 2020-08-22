#nullable enable

namespace System
{
    partial struct Optional<T>
    {
        public static readonly Optional<T> Absent;

        public static Optional<T> Present(T value)
            =>
            new Optional<T>(value);

        public static Optional<T> Wrap(Box<T>? box)
            =>
            new Optional<T>(box);
    }
}
