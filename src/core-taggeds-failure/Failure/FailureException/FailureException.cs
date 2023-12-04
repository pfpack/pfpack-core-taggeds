using System.Diagnostics.CodeAnalysis;

namespace System;

public sealed partial class FailureException<TFailureCode> : Exception
    where TFailureCode : struct
{
    public FailureException(TFailureCode failureCode, [AllowNull] string failureMessage, Exception? innerException)
        : base(failureMessage ?? string.Empty, innerException)
        =>
        FailureCode = failureCode;

    public TFailureCode FailureCode { get; }
}