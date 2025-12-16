namespace System;

partial struct Failure<TFailureCode>
{
    // We normalize empty message to null to get the default Exception message

    public Exception ToException()
        =>
        new(
            FailureCode,
            string.IsNullOrEmpty(FailureMessage) ? null : FailureMessage,
            SourceException);
}
