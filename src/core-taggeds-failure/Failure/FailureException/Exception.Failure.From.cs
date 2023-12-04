namespace System;

partial class FailureException<TFailureCode> 
{
    public FailureException(Failure<TFailureCode> failure)
        : base(failure.FailureMessage, failure.SourceException)
        =>
        FailureCode = failure.FailureCode;

    public static FailureException<TFailureCode> FromFailure(Failure<TFailureCode> failure)
        =>
        new(failure);
}