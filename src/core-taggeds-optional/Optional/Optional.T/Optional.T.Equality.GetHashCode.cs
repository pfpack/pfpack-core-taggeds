#nullable enable

using System.Runtime.CompilerServices;

namespace System
{
    partial struct Optional<T>
    {
        public override int GetHashCode()
            =>
            hasValue ? PresentHashCode() : AbsentHashCode();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private int PresentHashCode()
            =>
            HashCode.Combine(
                EqualityContract,
                value is not null ? EqualityComparer.GetHashCode(value) : default);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static int AbsentHashCode()
            =>
            HashCode.Combine(
                EqualityContract);
    }
}
