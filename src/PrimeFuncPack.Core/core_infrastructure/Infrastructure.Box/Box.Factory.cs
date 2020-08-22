#nullable enable

namespace System
{
    partial class Box
    {
        public static Box<T> Of<T>(T value) => new Box<T>(value);
    }
}
