#nullable enable

namespace System
{
    partial struct Result<TSuccess, TFailure>
    {
        public TSuccess SuccessOrThrow()
            =>
            Union.FirstOrThrow(CreateNotSuccessException);

        public TSuccess SuccessOrThrow(Func<Exception> exceptionFactory)
            =>
            Union.FirstOrThrow(exceptionFactory ?? throw new ArgumentNullException(nameof(exceptionFactory)));

        public TFailure FailureOrThrow()
            =>
            Union.SecondOrThrow(CreateNotFailureException);

        public TFailure FailureOrThrow(Func<Exception> exceptionFactory)
            =>
            Union.SecondOrThrow(exceptionFactory ?? throw new ArgumentNullException(nameof(exceptionFactory)));
    }
}
