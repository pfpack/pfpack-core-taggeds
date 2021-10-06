#nullable enable

using static System.FormattableString;

namespace System;

partial struct Failure<TFailureCode>
{
    public override string ToString()
        =>
        Invariant(
            $"A failure of {typeof(TFailureCode)}: {{ {nameof(FailureCode)}: {FailureCode}, {nameof(FailureMessage)}: \"{FailureMessage}\" }}");
}
