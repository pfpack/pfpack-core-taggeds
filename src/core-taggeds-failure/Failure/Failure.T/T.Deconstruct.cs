namespace System;

partial struct Failure<TFailureCode>
{
    public void Deconstruct(out TFailureCode failureCode, out string failureMessage)
    {
        failureCode = FailureCode;
        failureMessage = FailureMessage;
    }

    public void Deconstruct(out TFailureCode failureCode, out string failureMessage, out System.Exception? sourceException)
    {
        failureCode = FailureCode;
        failureMessage = FailureMessage;
        sourceException = SourceException;
    }
}
