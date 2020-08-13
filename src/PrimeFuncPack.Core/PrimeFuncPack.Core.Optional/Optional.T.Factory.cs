#nullable enable

namespace System
{
    partial struct Optional<T>
    {
        public static readonly Optional<T> Absent;

        public static Optional<T> Present(in T value)
            =>
            new Optional<T>(value);

        public static Optional<T> FromBox(in Box<T>? box)
            =>
            new Optional<T>(box);

        private Optional(in T value)
            =>
            box = value;

        private Optional(in Box<T>? box)
            =>
            this.box = box;
    }
}
