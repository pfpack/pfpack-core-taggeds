using static System.FormattableString;

namespace System;

partial struct Nonsuccess<TFailure>
{
    public override string ToString()
        =>
        Invariant($"Nonsuccess<{typeof(TFailure).Name}>:{failure}");
}
