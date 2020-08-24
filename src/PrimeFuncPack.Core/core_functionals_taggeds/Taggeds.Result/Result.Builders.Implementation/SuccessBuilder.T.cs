#nullable enable

using System;

namespace PrimeFuncPack.Core.Result.Builders
{
    // Not supposed for explicit use in a client code
    public sealed class SuccessBuilder<TSuccess> where TSuccess : notnull
    {
        private readonly TSuccess success;

        private SuccessBuilder(in TSuccess success)
            =>
            this.success = success;

        // Targeted for use in the Result factory / From wrapper methods only
        internal static SuccessBuilder<TSuccess> From(in TSuccess success)
            =>
            new SuccessBuilder<TSuccess>(success ?? throw new ArgumentNullException(nameof(success)));

        // The only member targeted for explicit use in a client code
        public Result<TSuccess, TFailure> Build<TFailure>() where TFailure : notnull, new()
            =>
            Result<TSuccess, TFailure>.Success(success);
    }
}
