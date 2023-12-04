namespace System;

partial struct Failure<TFailureCode>
{
    public Failure<TFailureCode>.Exception ToException()
        =>
        new(
            failureCode: FailureCode,
            message: failureMessage,
            innerException: SourceException);
}