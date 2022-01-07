namespace PrimeFuncPack.Core;

partial struct FailureBuilder<TFailure>
{
    // TODO: Implement ToString in according to TaggedUnion/Optional/Unit v2.0
    public override string ToString()
        =>
        failure.ToString() ?? string.Empty;
}
