#nullable enable

namespace System
{
    partial class Box
    {
        public static Box<T> Of<T>(in T value) => value;
    }
}
