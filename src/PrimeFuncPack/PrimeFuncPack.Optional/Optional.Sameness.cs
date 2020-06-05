#nullable enable

namespace PrimeFuncPack
{
    partial class Optional
    {
        public static bool Same<T>(in Optional<T> optionalA, in Optional<T> optionalB)
            =>
            Optional<T>.Same(optionalA, optionalB);
    }
}
