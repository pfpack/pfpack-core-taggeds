#nullable enable

using System;

namespace PrimeFuncPack.Core.Result.Builders
{
    internal sealed class FailureBuilderImpl<TFailure> : FailureBuilder<TFailure>
        where TFailure : notnull, new()
    {
        private FailureBuilderImpl(in TFailure failure) : base(failure)
        {
        }

        internal static FailureBuilderImpl<TFailure> Create(in TFailure failure)
            =>
            new FailureBuilderImpl<TFailure>(failure ?? throw new ArgumentNullException(nameof(failure)));
    }
}
