namespace System.Success;

partial class Success
{
    public static bool Equals<TSuccess>(Success<TSuccess> left, Success<TSuccess> right)
        =>
        left.Equals(right);
}
