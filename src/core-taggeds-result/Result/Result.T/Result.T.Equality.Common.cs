#nullable enable

using System.Collections.Generic;

namespace System
{
    partial struct Result<TSuccess, TFailure>
    {
        private static Type EqualityContract => typeof(Result<TSuccess, TFailure>);

        private static IEqualityComparer<TSuccess> SuccessComparer => EqualityComparer<TSuccess>.Default;

        private static IEqualityComparer<TFailure> FailureComparer => EqualityComparer<TFailure>.Default;
    }
}
