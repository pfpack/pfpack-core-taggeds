using System.Diagnostics.CodeAnalysis;

namespace System;

partial class Failure
{
    public static Failure<TFailureCode> Create<TFailureCode>(
        TFailureCode failureCode, [AllowNull] string failureMessage)
        where TFailureCode : struct
        =>
        new(failureCode, failureMessage);

    public static Failure<TFailureCode> Create<TFailureCode>(
        TFailureCode failureCode, [AllowNull] string failureMessage, Exception? sourceException)
        where TFailureCode : struct
        =>
        new(failureCode, failureMessage)
        {
            SourceException = sourceException
        };

    public static Failure<Unit> Create([AllowNull] string failureMessage)
        =>
        new(default, failureMessage);

    public static Failure<Unit> Create([AllowNull] string failureMessage, Exception? sourceException)
        =>
        new(default, failureMessage)
        {
            SourceException = sourceException
        };
}
