#nullable enable

namespace System
{
    partial struct Result<TSuccess, TFailure>
    {
        private Result(TaggedUnion<TSuccess, TFailure> unionRaw)
            =>
            this.unionRaw = unionRaw;
    }
}
