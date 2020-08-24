#nullable enable

using System;

namespace PrimeFuncPack.Core.Result.Builders
{
    // Targeted for use in the Result factory methods only
    // Not supposed for explicit use in a client code
    public readonly partial struct SuccessBuilder<TSuccess> where TSuccess : notnull
    {
        private readonly object? builderObj;

        private readonly TSuccess success;

        private SuccessBuilder(in TSuccess success)
        {
            builderObj = new object();
            this.success = success;
        }

        // Targeted for use in the Result factory / From wrapper methods only
        internal static SuccessBuilder<TSuccess> From(in TSuccess success)
            =>
            new SuccessBuilder<TSuccess>(success ?? throw new ArgumentNullException(nameof(success)));

        // The only member targeted for explicit use in a client code
        public Result<TSuccess, TFailure> Build<TFailure>() where TFailure : notnull, new() => builderObj switch
        {
            not null => Result<TSuccess, TFailure>.Success(success),
            _ => throw new InvalidOperationException("The success builder is not initialized.")
        };
    }
}
