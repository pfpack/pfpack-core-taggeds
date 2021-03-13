#nullable enable

namespace System
{
    partial struct Result<TSuccess, TFailure>
    {
        private Result(TaggedUnion<TSuccess, TFailure> union)
            =>
            this.union = union;
    }
}
