namespace System;

partial struct Failure<TFailureCode>
{
    public Exception ToException()
        =>
        new(
            failureCode: FailureCode,
            message: failureMessage,
            innerException: SourceException);
}