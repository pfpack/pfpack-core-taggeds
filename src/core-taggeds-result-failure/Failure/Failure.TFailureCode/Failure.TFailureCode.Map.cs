#nullable enable

namespace System
{
    partial struct Failure<TFailureCode>
    {
        public Failure<TResultFailureCode> Map<TResultFailureCode>(
            Func<TFailureCode, TResultFailureCode> mapFailureCode)
            where TResultFailureCode : struct
            =>
            InternalMap(
                mapFailureCode ?? throw new ArgumentNullException(nameof(mapFailureCode)));

        private Failure<TResultFailureCode> InternalMap<TResultFailureCode>(
            Func<TFailureCode, TResultFailureCode> mapFailureCode)
            where TResultFailureCode : struct
            =>
            new(
                failureCode: mapFailureCode.Invoke(failureCode),
                failureMessage: failureMessage);
    }
}