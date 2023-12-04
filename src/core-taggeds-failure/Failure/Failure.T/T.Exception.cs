namespace System;

partial struct Failure<TFailureCode>
{
    public sealed class Exception : System.Exception
    {
        internal Exception(TFailureCode failureCode, string? message, System.Exception? innerException)
            : base(message, innerException)
            =>
            FailureCode = failureCode;

        public TFailureCode FailureCode { get; }
    }
}