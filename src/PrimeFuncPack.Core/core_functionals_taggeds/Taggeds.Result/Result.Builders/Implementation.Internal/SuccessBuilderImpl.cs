#nullable enable

using System;

namespace PrimeFuncPack.Core.Result.Builders
{
    internal sealed class SuccessBuilderImpl<TSuccess> : SuccessBuilder<TSuccess>
        where TSuccess : notnull
    {
        private SuccessBuilderImpl(in TSuccess success) : base(success)
        {
        }

        internal static SuccessBuilderImpl<TSuccess> Create(in TSuccess success)
            =>
            new SuccessBuilderImpl<TSuccess>(success ?? throw new ArgumentNullException(nameof(success)));
    }
}
