namespace System;

partial struct Failure<TFailureCode>
{
    public FailureException<TFailureCode> AsException()
        =>
        new(this);
}