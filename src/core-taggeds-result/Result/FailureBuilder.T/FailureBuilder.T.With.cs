using System;

namespace PrimeFuncPack.Core;

partial struct FailureBuilder<TFailure>
{
    public Result<TSuccess, TFailure> With<TSuccess>()
        =>
        new(failure);
}
