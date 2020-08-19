#nullable enable

namespace System
{
    partial struct Optional<T>
    {
        public static readonly Optional<T> Absent;

        public static Optional<T> Present(in T value)
            =>
            new Optional<T>(value);

        public static Optional<T> Wrap(in Box<T>? box)
            =>
            new Optional<T>(box);
    }
}
