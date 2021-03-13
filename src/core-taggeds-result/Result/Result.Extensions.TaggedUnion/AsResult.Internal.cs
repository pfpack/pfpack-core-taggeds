#nullable enable

namespace System
{
    partial class TaggedUnionResultExtensions
    {
        internal static Result<TSuccess, TFailure> AsResult<TSuccess, TFailure>(
            this TaggedUnion<TSuccess, TFailure> union)
            where TFailure : struct
            =>
            Result<TSuccess, TFailure>.Wrap(union);
    }
}
