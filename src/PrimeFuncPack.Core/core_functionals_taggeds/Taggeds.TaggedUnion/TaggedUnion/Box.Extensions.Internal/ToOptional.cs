#nullable enable

namespace System
{
    partial class InternalBoxExtensions
    {
        public static Optional<T> ToOptional<T>(this in Box<T>? box)
            =>
            box switch { not null => Optional<T>.Present(box.Value), _ => Optional<T>.Absent };
    }
}
