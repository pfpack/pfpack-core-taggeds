using System.Diagnostics.CodeAnalysis;

namespace System;

partial class FailureExceptionExtensions
{
    public static Failure<TFailureCode> ToFailure<TFailureCode>(
        this Exception? sourceException, TFailureCode failureCode, [AllowNull] string failureMessage)
        where TFailureCode : struct
        =>
        new(failureCode, failureMessage)
        {
            SourceException = sourceException
        };

    public static Failure<Unit> ToFailure(
        this Exception? sourceException, [AllowNull] string failureMessage)
        =>
        new(default, failureMessage)
        {
            SourceException = sourceException
        };
}