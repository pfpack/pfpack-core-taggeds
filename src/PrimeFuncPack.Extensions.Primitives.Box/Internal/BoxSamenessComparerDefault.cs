#nullable enable

namespace PrimeFuncPack.Extensions.Primitives.Internal
{
    internal static class BoxSamenessComparerDefault<T>
    {
        public static readonly BoxSamenessComparer<T> Value = new BoxSamenessComparer<T>();
    }
}
