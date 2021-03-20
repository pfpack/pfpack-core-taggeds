#nullable enable

using System;
using System.Collections.Generic;

namespace PrimeFuncPack.Core
{
    partial struct SuccessBuilder<TSuccess>
    {
        private static Type EqualityContract => typeof(SuccessBuilder<TSuccess>);

        private static IEqualityComparer<TSuccess> SuccessComparer => EqualityComparer<TSuccess>.Default;
    }
}
