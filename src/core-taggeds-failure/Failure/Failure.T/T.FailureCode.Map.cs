using System.Runtime.CompilerServices;

namespace System;

partial struct Failure<TFailureCode>
{
    public Failure<TResultFailureCode> MapFailureCode<TResultFailureCode>(
        Func<TFailureCode, TResultFailureCode> mapFailureCode)
        where TResultFailureCode : struct
        =>
        InnerMapFailureCode(
            mapFailureCode ?? throw new ArgumentNullException(nameof(mapFailureCode)));

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private Failure<TResultFailureCode> InnerMapFailureCode<TResultFailureCode>(
        Func<TFailureCode, TResultFailureCode> mapFailureCode)
        where TResultFailureCode : struct
        =>
        new(
            failureCode: mapFailureCode.Invoke(FailureCode),
            failureMessage: failureMessage,
            _: default)
        {
            SourceException = SourceException
        };
}
