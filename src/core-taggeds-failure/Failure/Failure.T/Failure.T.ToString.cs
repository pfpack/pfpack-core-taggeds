#nullable enable

using static System.FormattableString;

namespace System;

partial struct Failure<TFailureCode>
{
    public override string ToString()
        =>
        Invariant(
            $"Failure[{typeof(TFailureCode)}]:{{ \"{nameof(FailureCode)}\": {FailureCode}, \"{nameof(FailureMessage)}\": \"{FailureMessage}\" }}");
}
