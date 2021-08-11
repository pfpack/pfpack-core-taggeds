#nullable enable

using System.Runtime.CompilerServices;

namespace System
{
    partial class Absent
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Absent<T> Get<T>()
            =>
            default;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Absent<T> Get<T>(Unit unit) => unit switch
        {
            _ => default
        };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Absent<T> From<T>(T result) => result switch
        {
            _ => default
        };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Absent<T> From<T, TResult>(TResult result) => result switch
        {
            _ => default
        };
    }
}
