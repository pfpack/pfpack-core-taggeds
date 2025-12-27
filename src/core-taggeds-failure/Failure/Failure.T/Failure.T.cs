using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace System;

public readonly partial struct Failure<TFailureCode> : IEquatable<Failure<TFailureCode>>
    where TFailureCode : struct
{
    // We use explicit backing fields for clarity in the inner state and the constructors compiled code

    private readonly TFailureCode failureCode;

    private readonly string? failureMessage;

    private readonly System.Exception? sourceException;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private Failure(TFailureCode failureCode, string? failureMessage, System.Exception? sourceException)
    {
        Debug.Assert(failureMessage is null or { Length: not 0 });

        this.failureCode = failureCode;
        this.failureMessage = failureMessage;
        this.sourceException = sourceException;
    }

    public Failure(TFailureCode failureCode, [AllowNull] string failureMessage)
    {
        this.failureCode = failureCode;
        this.failureMessage = string.IsNullOrEmpty(failureMessage) ? null : failureMessage;
        sourceException = null;

        Debug.Assert(this.failureMessage is null or { Length: not 0 });
    }

    public TFailureCode FailureCode
        =>
        failureCode;

    public string FailureMessage
        =>
        failureMessage ?? "";

    public System.Exception? SourceException
    {
        get => sourceException;
        init => sourceException = value;
    }
}
