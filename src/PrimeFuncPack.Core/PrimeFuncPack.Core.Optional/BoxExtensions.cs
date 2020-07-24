#nullable enable

namespace System
{
    public static class BoxExtensions
    {
        public static Optional<T> ToOptional<T>(this Box<T>? box) => box switch
        {
            null => default,
            var present => Optional<T>.Present(present)
        };
    }
}
