#nullable enable

using System;

namespace PrimeFuncPack.Core.Result.Builders
{
    internal sealed class ImplFailureBuilder<TFailure> : FailureBuilder<TFailure>
        where TFailure : notnull, new()
    {
        private ImplFailureBuilder(in TFailure failure) : base(failure)
        {
        }

        internal static ImplFailureBuilder<TFailure> Create(in TFailure failure)
            =>
            new ImplFailureBuilder<TFailure>(failure ?? throw new ArgumentNullException(nameof(failure)));
    }
}
