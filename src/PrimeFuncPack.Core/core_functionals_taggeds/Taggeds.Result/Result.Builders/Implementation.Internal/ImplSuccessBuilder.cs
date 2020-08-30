#nullable enable

using System;

namespace PrimeFuncPack.Core.Result.Builders
{
    internal sealed class ImplSuccessBuilder<TSuccess> : SuccessBuilder<TSuccess>
        where TSuccess : notnull
    {
        private ImplSuccessBuilder(in TSuccess success) : base(success)
        {
        }

        internal static ImplSuccessBuilder<TSuccess> Create(in TSuccess success)
            =>
            new ImplSuccessBuilder<TSuccess>(success ?? throw new ArgumentNullException(nameof(success)));
    }
}
