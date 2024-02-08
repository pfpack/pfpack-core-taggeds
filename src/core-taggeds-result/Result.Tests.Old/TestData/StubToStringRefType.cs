namespace PrimeFuncPack.Core.Tests;

internal sealed class StubToStringRefType
{
    private readonly string? toStringValue;

    public StubToStringRefType(
        string? toStringValue)
        =>
        this.toStringValue = toStringValue;

    public override string? ToString()
        => toStringValue;
}
