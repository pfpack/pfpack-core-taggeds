namespace PrimeFuncPack.Core;

partial struct SuccessBuilder<TSuccess>
{
    // TODO: Implement ToString in according to TaggedUnion/Optional/Unit v2.0
    public override string ToString()
        =>
        success?.ToString() ?? string.Empty;
}
