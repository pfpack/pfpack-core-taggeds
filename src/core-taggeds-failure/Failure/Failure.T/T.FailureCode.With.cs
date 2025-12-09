namespace System;

partial struct Failure<TFailureCode>
{
    public Failure<TNextFailureCode> WithFailureCode<TNextFailureCode>(
        TNextFailureCode nextFailureCode)
        where TNextFailureCode : struct
        =>
        new(
            nextFailureCode,
            failureMessage,
            default)
        {
            SourceException = SourceException
        };

    public Failure<TFailureCode> WithFailureCode(
        TFailureCode nextFailureCode)
        =>
        new(
            nextFailureCode,
            failureMessage,
            default)
        {
            SourceException = SourceException
        };
}
