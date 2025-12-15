namespace System;

partial struct Failure<TFailureCode>
{
    public Exception ToException()
        =>
        new(
            FailureCode,
            string.IsNullOrEmpty(FailureMessage) ? null : FailureMessage,
            SourceException);
}
