using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace System;

public readonly partial struct Failure<TFailureCode> :
    IEquatable<Failure<TFailureCode>>
    where TFailureCode : struct
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Failure(TFailureCode failureCode, [AllowNull] string failureMessage)
    {
        FailureCode = failureCode;
        FailureMessage = string.IsNullOrEmpty(failureMessage) ? null : failureMessage;
    }

    public TFailureCode FailureCode { get; }

    public string FailureMessage { get => field ?? ""; }

    public System.Exception? SourceException { get; init; }
}
