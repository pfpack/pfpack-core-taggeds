#nullable enable

namespace System
{
    partial struct Result<TSuccess, TFailure>
    {
        public TFailure FailureOrThrow()
            =>
            Union.SecondOrThrow(CreateNotFailureException);

        public TFailure FailureOrThrow(Func<Exception> exceptionFactory)
        {
            _ = exceptionFactory ?? throw new ArgumentNullException(nameof(exceptionFactory));

            return Union.SecondOrThrow(exceptionFactory);
        }
    }
}
