#nullable enable

using System.Runtime.CompilerServices;

namespace System
{
    partial struct TaggedUnion<TFirst, TSecond>
    {
        public override int GetHashCode()
        {
            if (tag == Tag.First)
            {
                return FirstHashCode();
            }

            if (tag == Tag.Second)
            {
                return SecondHashCode();
            }

            return UninitializedHashCode();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private int FirstHashCode()
            =>
            first is not null
                ? HashCode.Combine(EqualityContract, Tag.First, FirstComparer.GetHashCode(first))
                : HashCode.Combine(EqualityContract, Tag.First);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private int SecondHashCode()
            =>
            second is not null
                ? HashCode.Combine(EqualityContract, Tag.Second, SecondComparer.GetHashCode(second))
                : HashCode.Combine(EqualityContract, Tag.Second);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static int UninitializedHashCode()
            =>
            HashCode.Combine(EqualityContract);
    }
}
