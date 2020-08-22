#nullable enable

namespace System
{
    partial class Optional
    {
        public static bool Equals<T>(Optional<T> optionalA, Optional<T> optionalB)
            =>
            Optional<T>.Equals(optionalA, optionalB);
    }
}
