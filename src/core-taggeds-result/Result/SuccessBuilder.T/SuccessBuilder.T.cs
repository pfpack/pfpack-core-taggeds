namespace System;

public readonly partial struct SuccessBuilder<TSuccess> : IEquatable<SuccessBuilder<TSuccess>>
{
    private readonly TSuccess success;

    internal SuccessBuilder(TSuccess success)
        =>
        this.success = success;
}
