using System;
using System.Collections.Generic;

namespace PrimeFuncPack.Core;

partial struct SuccessBuilder<TSuccess>
{
    private static Type EqualityContract => typeof(SuccessBuilder<TSuccess>);

    private static EqualityComparer<TSuccess> SuccessComparer => EqualityComparer<TSuccess>.Default;
}
