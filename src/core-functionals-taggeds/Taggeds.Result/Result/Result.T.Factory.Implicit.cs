#nullable enable

using PrimeFuncPack.Core;

namespace System
{
    partial struct Result<TSuccess, TFailure>
    {
        public static implicit operator Result<TSuccess, TFailure>(in TSuccess success)
            =>
            new(success);

        public static implicit operator Result<TSuccess, TFailure>(in TFailure failure)
            =>
            new(failure);

        public static implicit operator Result<TSuccess, TFailure>(in SuccessBuilder<TSuccess> success)
            =>
            (success ?? throw new ArgumentNullException(nameof(success)))
            .Build<TFailure>();

        public static implicit operator Result<TSuccess, TFailure>(in FailureBuilder<TFailure> failure)
            =>
            failure.Build<TSuccess>();
    }
}
