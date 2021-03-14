#nullable enable

using System.Runtime.CompilerServices;

namespace System
{
    partial struct TaggedUnion<TFirst, TSecond>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private TFirst First() => first;
    }
}
