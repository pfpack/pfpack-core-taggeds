using System.Diagnostics.CodeAnalysis;

namespace System;

partial class Failure
{
    public static Failure<TFailureCode> Create<TFailureCode>(
        TFailureCode failureCode,
        [AllowNull] string failureMessage)
        where TFailureCode : struct
        =>
        new(
            failureCode: failureCode,
            failureMessage: failureMessage);
}
