#nullable enable

namespace System
{
    partial struct Result<TSuccess, TFailure>
    {
        public static bool Equals(Result<TSuccess, TFailure> resultA, Result<TSuccess, TFailure> resultB)
            =>
            TaggedUnion.Equals(resultA.Union, resultB.Union);

        public static bool operator ==(Result<TSuccess, TFailure> resultA, Result<TSuccess, TFailure> resultB)
            =>
            Equals(resultA, resultB);

        public static bool operator !=(Result<TSuccess, TFailure> resultA, Result<TSuccess, TFailure> resultB)
            =>
            Equals(resultA, resultB) is false;

        public bool Equals(Result<TSuccess, TFailure> other)
            =>
            Equals(this, other);

        public override bool Equals(object? obj)
            =>
            obj is Result<TSuccess, TFailure> other &&
            Equals(this, other);

        public override int GetHashCode() => HashCode.Combine(
            typeof(Result<TSuccess, TFailure>),
            Union.GetHashCode());
    }
}
