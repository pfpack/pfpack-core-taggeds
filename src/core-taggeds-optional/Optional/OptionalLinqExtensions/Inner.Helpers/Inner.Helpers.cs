using System.Runtime.CompilerServices;

namespace System.Linq;

partial class OptionalLinqExtensions
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static bool InnerIsInRange(int index, int count)
        =>
        index >= 0 && index < count;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static int InnerShorten(long index)
        =>
        unchecked((int)index);
}
