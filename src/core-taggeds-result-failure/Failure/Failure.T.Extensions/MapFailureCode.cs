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
        {
            _ = mapFailureCode ?? throw new ArgumentNullException(nameof(mapFailureCode));

            return new(
                failureCode: mapFailureCode.Invoke(failure.FailureCode),
                failureMessage: failure.FailureMessage);
        }
    }
}
