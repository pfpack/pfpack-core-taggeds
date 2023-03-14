using System.Threading.Tasks;

namespace System;

partial struct Result<TSuccess, TFailure>
{
    public Result<TResultSuccess, TResultFailure> Map<TResultSuccess, TResultFailure>(
        Func<TSuccess, TResultSuccess> mapSuccess,
        Func<TFailure, TResultFailure> mapFailure)
        where TResultFailure : struct
        =>
        InnerMap(
            mapSuccess ?? throw new ArgumentNullException(nameof(mapSuccess)),
            mapFailure ?? throw new ArgumentNullException(nameof(mapFailure)));
}
