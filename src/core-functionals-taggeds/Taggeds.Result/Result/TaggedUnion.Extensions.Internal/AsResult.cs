#nullable enable

namespace System
{
    partial class InternalTaggedUnionExtensions
    {
        internal static Result<TSuccess, TFailure> AsResult<TSuccess, TFailure>(
            this in TaggedUnion<TSuccess, TFailure> unionRaw)
            where TSuccess : notnull
            where TFailure : struct
            =>
            Result<TSuccess, TFailure>.Wrap(unionRaw);
    }
}
