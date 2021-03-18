#nullable enable

namespace System
{
    partial struct Result<TSuccess, TFailure>
    {
        public override int GetHashCode()
            =>
            HashCode.Combine(EqualityContract, Union.GetHashCode());
    }
}
