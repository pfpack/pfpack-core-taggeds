namespace System;

partial struct Failure<TFailureCode>
{
    public Failure<TResultFailureCode> MapFailureCode<TResultFailureCode>(
        Func<TFailureCode, TResultFailureCode> mapFailureCode)
        where TResultFailureCode : struct
        =>
        InnerMapFailureCode(
            mapFailureCode ?? throw new ArgumentNullException(nameof(mapFailureCode)));
}
