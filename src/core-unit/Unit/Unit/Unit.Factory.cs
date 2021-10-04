#nullable enable

using System.Runtime.CompilerServices;

namespace System;

partial struct Unit
{
    public static readonly Unit Value;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Unit Get()
        =>
        default;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Unit From<TResult>(TResult result) => result switch
    {
        _ => default
    };
}
