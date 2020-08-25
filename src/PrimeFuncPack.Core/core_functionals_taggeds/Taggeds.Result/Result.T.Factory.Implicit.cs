#nullable enable

using PrimeFuncPack.Core.Result.Builders;

namespace System
{
    partial struct Result<TSuccess, TFailure>
    {
        public static implicit operator Result<TSuccess, TFailure>(in SuccessBuilder<TSuccess> success)
            =>
            (success ?? throw new ArgumentNullException(nameof(success)))
            .Build<TFailure>();

        public static implicit operator Result<TSuccess, TFailure>(in FailureBuilder<TFailure> failure)
            =>
            (failure ?? throw new ArgumentNullException(nameof(failure)))
            .Build<TSuccess>();
    }
}
