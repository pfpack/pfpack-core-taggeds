#nullable enable

namespace PrimeFuncPack
{
    partial class Box
    {
        public static bool Same<T>(in Box<T>? boxA, in Box<T>? boxB)
            =>
            Box<T>.Same(boxA, boxB);
    }
}
