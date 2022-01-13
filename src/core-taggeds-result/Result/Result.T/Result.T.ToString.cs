namespace System;

partial struct Result<TSuccess, TFailure>
{
    // TODO: Implement ToString in according to TaggedUnion/Optional/Unit v2.0
    public override string ToString()
        =>
        InnerFold(
            value => value?.ToString() ?? string.Empty,
            value => value.ToString() ?? string.Empty);
}
