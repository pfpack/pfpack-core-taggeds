namespace System;

partial struct Failure<TFailureCode>
{
    public Failure<TResultFailureCode> MapFailureCode<TResultFailureCode>(
        Func<TFailureCode, TResultFailureCode> mapFailureCode)
        where TResultFailureCode : struct
    {
        _ = mapFailureCode ?? throw new ArgumentNullException(nameof(mapFailureCode));

        return new(
            failureCode: mapFailureCode.Invoke(FailureCode),
            failureMessage: FailureMessage);
    }
}
