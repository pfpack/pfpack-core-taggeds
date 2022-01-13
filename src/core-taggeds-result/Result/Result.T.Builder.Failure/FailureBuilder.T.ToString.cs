using static System.FormattableString;

namespace PrimeFuncPack.Core;

partial struct FailureBuilder<TFailure>
{
    public override string ToString()
        =>
        Invariant($"FailureBuilder[{typeof(TFailure)}]:{failure}");
}
