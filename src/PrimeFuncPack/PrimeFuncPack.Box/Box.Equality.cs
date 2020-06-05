#nullable enable

namespace PrimeFuncPack
{
    partial class Box
    {
        public static bool Equals<T>(in Box<T>? boxA, in Box<T>? boxB)
            =>
            Box<T>.Equals(boxA, boxB);
    }
}
