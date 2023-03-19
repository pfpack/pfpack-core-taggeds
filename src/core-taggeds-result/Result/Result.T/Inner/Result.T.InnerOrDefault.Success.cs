using System.Runtime.CompilerServices;

namespace System;

partial struct Result<TSuccess, TFailure>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private TSuccess? InnerSuccessOrDefault()
        =>
        isSuccess ? success : default;
}
