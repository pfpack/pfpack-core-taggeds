using static System.FormattableString;

namespace System;

partial struct Failure<TFailureCode>
{
    public override string ToString()
        =>
        Invariant(
            $"Failure[{typeof(TFailureCode)}]:{{ \"FailureCode\": {FailureCode}, \"FailureMessage\": \"{FailureMessage}\" }}");
}
