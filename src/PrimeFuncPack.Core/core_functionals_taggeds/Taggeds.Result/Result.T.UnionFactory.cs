#nullable enable

namespace System
{
    partial struct Result<TSuccess, TFailure>
    {
        private static TaggedUnion<TSuccess, TFailure> UnionSuccess(in TSuccess success)
            =>
            TaggedUnion<TSuccess, TFailure>.First(success);

        private static TaggedUnion<TSuccess, TFailure> UnionFailure(in TFailure failure)
            =>
            TaggedUnion<TSuccess, TFailure>.Second(failure);
    }
}
