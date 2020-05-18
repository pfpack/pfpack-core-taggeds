#nullable enable

namespace PrimeFuncPack.Extensions.Primitives
{
    partial class Box
    {
        public static bool Equals<T>(in Box<T>? boxA, in Box<T>? boxB)
            =>
            Box<T>.Equals(boxA, boxB);
    }
}
