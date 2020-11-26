#nullable enable

namespace System
{
    partial struct Result<TSuccess, TFailure>
    {
        internal static Result<TSuccess, TFailure> Wrap(in TaggedUnion<TSuccess, TFailure> union)
            =>
            new(union);
    }
}
