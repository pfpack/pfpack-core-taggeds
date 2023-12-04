namespace System;

partial class FailureException<TFailureCode> 
{
    public Failure<TFailureCode> ToFailure()
        =>
        new(
            failureCode: FailureCode,
            failureMessage: Message)
        {
            SourceException = InnerException
        };
}