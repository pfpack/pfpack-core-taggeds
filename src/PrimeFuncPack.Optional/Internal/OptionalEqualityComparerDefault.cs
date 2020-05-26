#nullable enable

namespace PrimeFuncPack
{
    internal static class OptionalEqualityComparerDefault<T>
    {
        public static readonly OptionalEqualityComparer<T> Value = new OptionalEqualityComparer<T>();
    }
}
