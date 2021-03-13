#nullable enable

namespace System
{
    partial class FailureExtensions
    {
        public static Failure<TResultFailureCode> MapFailureCode<TFailureCode, TResultFailureCode>(
            this Failure<TFailureCode> failure,
            Func<TFailureCode, TResultFailureCode> mapFailureCode)
            where TFailureCode : struct
            where TResultFailureCode : struct
            =>
            failure.InternalMapFailureCode(
                mapFailureCode ?? throw new ArgumentNullException(nameof(mapFailureCode)));

        private static Failure<TResultFailureCode> InternalMapFailureCode<TFailureCode, TResultFailureCode>(
            this Failure<TFailureCode> failure,
            Func<TFailureCode, TResultFailureCode> mapFailureCode)
            where TFailureCode : struct
            where TResultFailureCode : struct
            =>
            new(
                failureCode: mapFailureCode.Invoke(failure.FailureCode),
                failureMessage: failure.FailureMessage);
    }
}