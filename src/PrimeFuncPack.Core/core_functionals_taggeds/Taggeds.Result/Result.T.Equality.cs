#nullable enable

namespace System
{
    partial struct Result<TSuccess, TFailure>
    {
        public static bool Equals(Result<TSuccess, TFailure> resultA, Result<TSuccess, TFailure> resultB)
            =>
            TaggedUnion<TSuccess, TFailure>.Equals(resultA.union, resultB.union);

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

        public override int GetHashCode()
            =>
            HashCode.Combine(EqualityContract, union);

        private static Type EqualityContract => typeof(Result<TSuccess, TFailure>);
    }
}
