namespace System;

partial struct Failure<TFailureCode>
{
    public Failure<TFailureCode> FromException(FailureException<TFailureCode> exception)
    {
        _ = exception ?? throw new ArgumentNullException(nameof(exception));

        return new(
            failureCode: exception.FailureCode,
            failureMessage: exception.Message)
        {
            SourceException = exception.InnerException
        };
    }
}