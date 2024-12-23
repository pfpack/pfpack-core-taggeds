using static System.FormattableString;

namespace System;

partial struct FailureBuilder<TFailure>
{
    public override string ToString()
        =>
        Invariant($"FailureBuilder<{typeof(TFailure).Name}>:{failure}");
}
