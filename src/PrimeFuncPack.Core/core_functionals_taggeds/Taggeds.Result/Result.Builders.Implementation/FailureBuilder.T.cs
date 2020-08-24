#nullable enable

using System;

namespace PrimeFuncPack.Core.Result.Builders
{
    // Targeted for use in the Result factory methods only
    // Not supposed for explicit use in a client code
    public readonly partial struct FailureBuilder<TFailure> where TFailure : notnull, new()
    {
        private readonly object? builderObj;

        private readonly TFailure failure;

        private FailureBuilder(in TFailure failure)
        {
            builderObj = new object();
            this.failure = failure;
        }

        // Targeted for use in the Result Failure factory method only
        internal static FailureBuilder<TFailure> From(in TFailure failure)
            =>
            new FailureBuilder<TFailure>(failure ?? throw new ArgumentNullException(nameof(failure)));

        // The only member targeted for explicit use in a client code
        public Result<TSuccess, TFailure> Build<TSuccess>() where TSuccess : notnull => builderObj switch
        {
            not null => Result<TSuccess, TFailure>.Failure(failure),
            _ => throw new InvalidOperationException("The failure builder is not initialized.")
        };
    }
}
