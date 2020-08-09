#nullable enable

namespace System
{
    public static class BoxExtensions
    {
        public static Optional<T> ToOptional<T>(this Box<T>? box) => box switch
        {
            not null => Optional<T>.Present(box),
            _ => default
        };
    }
}
