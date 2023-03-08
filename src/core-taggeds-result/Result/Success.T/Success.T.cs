namespace System;

// TODO: Add the tests!
public readonly partial struct Success<TSuccess> : IEquatable<Success<TSuccess>>
{
    private readonly TSuccess success;

    internal TSuccess InternalSuccess
        =>
        success;
}
