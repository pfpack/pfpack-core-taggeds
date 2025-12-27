namespace System;

partial struct Failure<TFailureCode>
{
    public Failure<TNextFailureCode> WithFailureCode<TNextFailureCode>(
        TNextFailureCode nextFailureCode)
        where TNextFailureCode : struct
        =>
        new(
            nextFailureCode,
            failureMessage, // pass the inner state
            SourceException);

    public Failure<TFailureCode> WithFailureCode(
        TFailureCode nextFailureCode)
        =>
        new(
            nextFailureCode,
            failureMessage, // pass the inner state
            SourceException);
}
