#nullable enable

namespace PrimeFuncPack
{
    partial class Optional
    {
        public static bool Equals<T>(in Optional<T> optionalA, in Optional<T> optionalB)
            =>
            Optional<T>.Equals(optionalA, optionalB);
    }
}
