#nullable enable

namespace System
{
    partial struct Result<TSuccess, TFailure>
    {
        public TSuccess SuccessOrThrow()
            =>
            Union.FirstOrThrow(CreateNotSuccessException);

        public TSuccess SuccessOrThrow(Func<Exception> exceptionFactory)
        {
            _ = exceptionFactory ?? throw new ArgumentNullException(nameof(exceptionFactory));

            return Union.FirstOrThrow(exceptionFactory);
        }
    }
}
