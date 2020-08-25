#nullable enable

namespace System
{
    partial struct Result<TSuccess, TFailure>
    {
        public TSuccess SuccessOrThrow()
            =>
            SuccessOrThrow(CreateNotSuccessException);

        public TSuccess SuccessOrThrow(Func<Exception> exceptionFactory)
        {
            _ = exceptionFactory ?? throw new ArgumentNullException(nameof(exceptionFactory));

            return SuccessSource.FirstOrThrow(exceptionFactory);
        }

        public TFailure FailureOrThrow()
            =>
            FailureOrThrow(CreateNotFailureException);

        public TFailure FailureOrThrow(Func<Exception> exceptionFactory)
        {
            _ = exceptionFactory ?? throw new ArgumentNullException(nameof(exceptionFactory));

            return FailureSource.SecondOrThrow(exceptionFactory);
        }

        private TaggedUnion<TSuccess, TFailure> SuccessSource => unionRaw;

        private TaggedUnion<TSuccess, TFailure> FailureSource => Union;
    }
}
