using System.Runtime.CompilerServices;
using static System.FormattableString;

namespace System;

partial struct Result<TSuccess, TFailure>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private string InnerToString()
        =>
        InnerFold(InnerToStringSuccess, InnerToStringFailure);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static string InnerToStringSuccess(TSuccess success)
        =>
        Invariant($"{InnerToStringPrefix()}:Success:{success}");

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static string InnerToStringFailure(TFailure failure)
        =>
        Invariant($"{InnerToStringPrefix()}:Failure:{failure}");

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static string InnerToStringPrefix()
        =>
        Invariant($"Result[{typeof(TSuccess)},{typeof(TFailure)}]");
}
