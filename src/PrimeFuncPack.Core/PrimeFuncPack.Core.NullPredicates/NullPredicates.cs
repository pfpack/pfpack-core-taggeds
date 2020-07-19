#nullable enable

namespace System
{
    public static class NullPredicates
    {
        public static bool IsNotNull<T>(T value)
            =>
            value is object;

        public static bool IsNull<T>(T value)
            =>
            value is null;
    }
}
