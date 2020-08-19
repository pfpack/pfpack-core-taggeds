#nullable enable

namespace System
{
    partial class Optional
    {
        public static bool Same<T>(Optional<T> optionalA, Optional<T> optionalB)
            =>
            Optional<T>.Same(optionalA, optionalB);
    }
}
