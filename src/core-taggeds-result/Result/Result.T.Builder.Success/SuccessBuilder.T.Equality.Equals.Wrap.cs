namespace PrimeFuncPack.Core;

partial struct SuccessBuilder<TSuccess>
{
    // TODO: Add test and open the method
    internal static bool Equals(SuccessBuilder<TSuccess> left, SuccessBuilder<TSuccess> right)
        =>
        left.Equals(right);

    public static bool operator ==(SuccessBuilder<TSuccess> left, SuccessBuilder<TSuccess> right)
        =>
        left.Equals(right);

    public static bool operator !=(SuccessBuilder<TSuccess> left, SuccessBuilder<TSuccess> right)
        =>
        left.Equals(right) is false;

    public override bool Equals(object? obj)
        =>
        obj is SuccessBuilder<TSuccess> other &&
        Equals(other);
}
