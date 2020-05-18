#nullable enable

namespace PrimeFuncPack.Extensions.Primitives.Internal
{
    internal static class BoxEqualityComparerDefault<T>
    {
        public static readonly BoxEqualityComparer<T> Value = new BoxEqualityComparer<T>();
    }
}
