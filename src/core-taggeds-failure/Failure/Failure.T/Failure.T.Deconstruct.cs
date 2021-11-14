namespace System;

partial struct Failure<TFailureCode>
{
    public void Deconstruct(out TFailureCode failureCode, out string failureMessage)
    {
        failureCode = FailureCode;
        failureMessage = FailureMessage;
    }
}
