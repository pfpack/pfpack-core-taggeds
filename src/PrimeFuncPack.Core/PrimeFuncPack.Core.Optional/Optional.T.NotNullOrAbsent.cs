#nullable enable

using static System.NullPredicates;

namespace System
{
    partial struct Optional<T>
    {
        public Optional<T> NotNullOrAbsent() => Filter(IsNotNull);
    }
}
