using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace System;

partial struct Result<TSuccess, TFailure>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private Result<TSuccess, TResultFailure> InnerMapFailure<TResultFailure>(
        Func<TFailure, TResultFailure> mapFailure)
        where TResultFailure : struct
        =>
        isSuccess
            ? new(success)
            : new(mapFailure.Invoke(failure));
}
