#nullable enable

using System.Runtime.CompilerServices;

namespace System
{
    partial struct Optional<T>
    {
        public override int GetHashCode()
            =>
            hasValue
                ? HashCode.Combine(EqualityContract, ValueHashCode())
                : HashCode.Combine(EqualityContract);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private int ValueHashCode()
            =>
            value is not null ? EqualityComparer.GetHashCode(value) : default;
    }
}
