namespace System;

partial struct Failure<TFailureCode>
{
    public Failure<TNextFailureCode> WithFailureCode<TNextFailureCode>(
        TNextFailureCode nextFailureCode)
        where TNextFailureCode : struct
        =>
        new(
            nextFailureCode,
            FailureMessage)
        {
            SourceException = SourceException
        };

    public Failure<TFailureCode> WithFailureCode(
        TFailureCode nextFailureCode)
        =>
        new(
            nextFailureCode,
            FailureMessage)
        {
            SourceException = SourceException
        };
}
