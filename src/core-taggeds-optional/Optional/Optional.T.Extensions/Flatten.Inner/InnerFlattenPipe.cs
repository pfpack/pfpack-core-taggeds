using System.Runtime.CompilerServices;

namespace System;

partial class OptionalExtensions
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static Optional<T> InnerFlattenPipe<T>(Optional<T> optional) => optional;
}
