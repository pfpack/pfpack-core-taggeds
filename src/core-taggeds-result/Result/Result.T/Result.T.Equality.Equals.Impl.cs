#nullable enable

namespace System
{
    partial struct Result<TSuccess, TFailure>
    {
        public bool Equals(Result<TSuccess, TFailure> other)
            =>
            Union.Equals(other.Union);
    }
}
