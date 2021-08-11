#nullable enable

using System.Runtime.CompilerServices;

namespace System
{
    partial struct Absent<T>
    {
        public static readonly Absent<T> Value;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Absent<T> Get()
            =>
            default;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Absent<T> Get(Unit unit) => unit switch
        {
            _ => default
        };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Absent<T> From(T result) => result switch
        {
            _ => default
        };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Absent<T> From<TResult>(TResult result) => result switch
        {
            _ => default
        };
    }
}
