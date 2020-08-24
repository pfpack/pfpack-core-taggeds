#nullable enable

using System;

namespace PrimeFuncPack.Core.Result.Builders
{
    // Targeted for use in the Result factory methods only
    // Not supposed for explicit use in a client code
    public sealed class FailureBuilder<TFailure> where TFailure : notnull, new()
    {
        private readonly TFailure failure;

        private FailureBuilder(in TFailure failure)
            =>
            this.failure = failure;

        // Targeted for use in the Result factory / From wrapper methods only
        internal static FailureBuilder<TFailure> From(in TFailure failure)
            =>
            new FailureBuilder<TFailure>(failure ?? throw new ArgumentNullException(nameof(failure)));

        // The only member targeted for explicit use in a client code
        public Result<TSuccess, TFailure> Build<TSuccess>() where TSuccess : notnull
            =>
            Result<TSuccess, TFailure>.Failure(failure);
    }
}
