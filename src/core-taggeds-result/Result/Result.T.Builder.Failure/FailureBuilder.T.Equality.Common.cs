using System;
using System.Collections.Generic;

namespace PrimeFuncPack.Core
{
    partial struct FailureBuilder<TFailure>
    {
        private static Type EqualityContract => typeof(FailureBuilder<TFailure>);

        private static IEqualityComparer<TFailure> FailureComparer => EqualityComparer<TFailure>.Default;
    }
}
