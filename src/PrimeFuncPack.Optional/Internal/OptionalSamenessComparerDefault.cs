#nullable enable

namespace PrimeFuncPack.Internal
{
    internal static class OptionalSamenessComparerDefault<T>
    {
        public static readonly OptionalSamenessComparer<T> Value = new OptionalSamenessComparer<T>();
    }
}
