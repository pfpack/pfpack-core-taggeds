using System.Runtime.CompilerServices;

namespace System;

partial class UnitExtensions
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Unit ToUnit<TResult>(this TResult result)
        =>
        Unit.From(result);
}
