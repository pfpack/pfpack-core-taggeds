namespace System;

partial struct Failure<TFailureCode>
{
    public Failure<TNextFailureCode> WithFailureCode<TNextFailureCode>(
        TNextFailureCode nextFailureCode)
        where TNextFailureCode : struct
        =>
        new(
            failureCode: nextFailureCode,
            failureMessage: failureMessage,
            _: default)
        {
            SourceException = SourceException
        };

    public Failure<TFailureCode> WithFailureCode(
        TFailureCode nextFailureCode)
        =>
        new(
            failureCode: nextFailureCode,
            failureMessage: failureMessage,
            _: default)
        {
            SourceException = SourceException
        };
}
