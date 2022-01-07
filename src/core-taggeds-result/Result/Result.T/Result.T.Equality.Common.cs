using System.Collections.Generic;

namespace System;

partial struct Result<TSuccess, TFailure>
{
    private static Type EqualityContract => typeof(Result<TSuccess, TFailure>);

    private static EqualityComparer<TSuccess> SuccessComparer => EqualityComparer<TSuccess>.Default;

    private static EqualityComparer<TFailure> FailureComparer => EqualityComparer<TFailure>.Default;
}
