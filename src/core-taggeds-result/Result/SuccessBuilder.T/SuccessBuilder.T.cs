using System;

// TODO: Move to System namespace in Result v3.0
namespace PrimeFuncPack.Core;

public readonly partial struct SuccessBuilder<TSuccess> : IEquatable<SuccessBuilder<TSuccess>>
{
    private readonly TSuccess success;

    internal SuccessBuilder(TSuccess success)
        =>
        this.success = success;
}
