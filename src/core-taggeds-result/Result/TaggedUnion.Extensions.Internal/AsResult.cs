#nullable enable

namespace System
{
    partial class InternalTaggedUnionExtensions
    {
        internal static Result<TSuccess, TFailure> AsResult<TSuccess, TFailure>(
            this TaggedUnion<TSuccess, TFailure> unionRaw)
            where TFailure : struct
            =>
            Result<TSuccess, TFailure>.Wrap(unionRaw);
    }
}
