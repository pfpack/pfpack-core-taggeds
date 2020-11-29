#nullable enable

namespace System
{
    partial struct Result<TSuccess, TFailure>
    {
        private Result(in TaggedUnion<TSuccess, TFailure> unionRaw)
            =>
            this.unionRaw = unionRaw;
    }
}
