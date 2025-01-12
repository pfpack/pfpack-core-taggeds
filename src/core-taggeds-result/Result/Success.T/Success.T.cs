namespace System;

// TODO: Add the tests and open the type
internal readonly partial struct Success<TSuccess> : IEquatable<Success<TSuccess>>
{
    private readonly TSuccess success;
}
