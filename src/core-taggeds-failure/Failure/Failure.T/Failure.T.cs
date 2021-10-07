#nullable enable

using System.Diagnostics.CodeAnalysis;

namespace System;

public readonly partial struct Failure<TFailureCode> : IEquatable<Failure<TFailureCode>>
    where TFailureCode : struct
{
    private readonly TFailureCode failureCode;

    private readonly string? failureMessage;

    public Failure(
        TFailureCode failureCode,
        [AllowNull] string failureMessage)
    {
        this.failureCode = failureCode;
        this.failureMessage = InnerOrNullIfEmpty(failureMessage);
    }

    public TFailureCode FailureCode
        =>
        failureCode;

    public string FailureMessage
        =>
        failureMessage ?? string.Empty;
}
