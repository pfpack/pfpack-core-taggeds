using System.Runtime.CompilerServices;
using static System.FormattableString;

namespace System;

partial struct Result<TSuccess, TFailure>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private string InnerToString()
        =>
        InnerFold(
            success => InnerToString("Success", success),
            failure => InnerToString("Failure", failure));

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static string InnerToString<TValue>(string tag, TValue value)
        =>
        Invariant($"Result<{typeof(TSuccess).Name}, {typeof(TFailure).Name}>:{tag}:{value}");
}
