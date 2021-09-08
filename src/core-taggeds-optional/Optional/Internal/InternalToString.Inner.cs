#nullable enable

using System.Runtime.CompilerServices;
using static System.FormattableString;

namespace System
{
    partial class InternalToString<T>
    {
        private const string InnerAbsentValue = "()";

        private static class InnerFormatter<TResult>
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static string Invoke(string prefix, TResult value)
                =>
                Invariant($"{prefix}[{typeof(T)}]:{value}");
        }
    }
}
