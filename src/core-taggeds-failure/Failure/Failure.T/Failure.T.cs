using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace System;

public readonly partial struct Failure<TFailureCode> : IEquatable<Failure<TFailureCode>>
    where TFailureCode : struct
{
    private readonly TFailureCode failureCode;

    private readonly string? failureMessage;

    private Failure(TFailureCode failureCode, string? failureMessage, int _)
    {
        Debug.Assert(failureMessage is null || failureMessage.Length != default);

        this.failureCode = failureCode;
        this.failureMessage = failureMessage;
    }

    public Failure(TFailureCode failureCode, [AllowNull] string failureMessage)
    {
        this.failureCode = failureCode;
        this.failureMessage = string.IsNullOrEmpty(failureMessage) ? null : failureMessage;

        Debug.Assert(this.failureMessage is null || this.failureMessage.Length != default);
    }

    public TFailureCode FailureCode
        =>
        failureCode;

    public string FailureMessage
        =>
        failureMessage ?? "";

    public System.Exception? SourceException { get; init; }
}
