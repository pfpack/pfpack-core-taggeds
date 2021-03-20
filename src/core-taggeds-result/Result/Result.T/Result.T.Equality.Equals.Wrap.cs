#nullable enable

namespace System
{
    partial struct Result<TSuccess, TFailure>
    {
        public static bool Equals(Result<TSuccess, TFailure> left, Result<TSuccess, TFailure> right)
            =>
            left.Equals(right);

        public static bool operator ==(Result<TSuccess, TFailure> left, Result<TSuccess, TFailure> right)
            =>
            left.Equals(right);

        public static bool operator !=(Result<TSuccess, TFailure> left, Result<TSuccess, TFailure> right)
            =>
            left.Equals(right) is false;

        public override bool Equals(object? obj)
            =>
            obj is Result<TSuccess, TFailure> other &&
            Equals(other);
    }
}
