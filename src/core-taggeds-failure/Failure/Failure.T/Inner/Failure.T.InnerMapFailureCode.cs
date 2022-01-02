namespace System;

partial struct Failure<TFailureCode>
{
    private Failure<TResultFailureCode> InnerMapFailureCode<TResultFailureCode>(
        Func<TFailureCode, TResultFailureCode> mapFailureCode)
        where TResultFailureCode : struct
        =>
        new(
            failureCode: mapFailureCode.Invoke(FailureCode),
            failureMessage: FailureMessage);
}
