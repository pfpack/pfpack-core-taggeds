#nullable enable

using PrimeFuncPack.Core.Result.Builders;

namespace System
{
    partial struct Result<TSuccess, TFailure>
    {
        public static implicit operator Result<TSuccess, TFailure>(in SuccessBuilder<TSuccess> success)
        {
            _ = success ?? throw new ArgumentNullException(nameof(success));

            return success.Build<TFailure>();
        }

        public static implicit operator Result<TSuccess, TFailure>(in FailureBuilder<TFailure> failure)
        {
            _ = failure ?? throw new ArgumentNullException(nameof(failure));

            return failure.Build<TSuccess>();
        }
    }
}
