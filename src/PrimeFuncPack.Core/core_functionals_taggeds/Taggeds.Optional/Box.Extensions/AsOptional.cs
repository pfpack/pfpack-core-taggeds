#nullable enable

namespace System
{
    partial class BoxExtensions
    {
        public static Optional<T> AsOptional<T>(this Box<T>? box)
            =>
            Optional<T>.Wrap(box);
    }
}
