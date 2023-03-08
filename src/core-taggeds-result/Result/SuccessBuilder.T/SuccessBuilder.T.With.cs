using System;

namespace PrimeFuncPack.Core;

partial struct SuccessBuilder<TSuccess>
{
    public Result<TSuccess, TFailure> With<TFailure>()
        where TFailure : struct
        =>
        new(success);
}
