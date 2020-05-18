#nullable enable

namespace PrimeFuncPack.Internal
{
    internal static class OptionalEqualityComparerDefault<T>
    {
        public static readonly OptionalEqualityComparer<T> Value = new OptionalEqualityComparer<T>();
    }
}
