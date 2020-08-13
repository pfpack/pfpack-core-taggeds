#nullable enable

namespace System
{
    public static class BoxExtensions
    {
        public static Optional<T> AsOptional<T>(this Box<T>? box) => Optional<T>.Wrap(box);
    }
}
