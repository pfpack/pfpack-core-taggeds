#nullable enable

using System.Runtime.CompilerServices;
using static System.FormattableString;

namespace System
{
    partial class InternalToString<T>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static string InnerPresent(string prefix, T value)
            =>
            Invariant($"{prefix}[{typeof(T)}]:{value}");

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static string InnerAbsent(string prefix)
            =>
            Invariant($"{prefix}[{typeof(T)}]:()");
    }
}
