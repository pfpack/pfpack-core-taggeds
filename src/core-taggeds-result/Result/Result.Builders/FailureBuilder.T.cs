#nullable enable

using System;

namespace PrimeFuncPack.Core
{
    public readonly partial struct FailureBuilder<TFailure> :
        IEquatable<FailureBuilder<TFailure>>
        where TFailure : struct
    {
        private readonly TFailure failure;

        internal FailureBuilder(TFailure failure)
            =>
            this.failure = failure;

        public Result<TSuccess, TFailure> With<TSuccess>()
            =>
            failure;
    }
}
