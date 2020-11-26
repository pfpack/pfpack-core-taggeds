#nullable enable

namespace System
{
    internal static class ResultUnionExtensions
    {
        public static TaggedUnion<TSuccess, TFailure> OrFailure<TSuccess, TFailure>(
            this in TaggedUnion<TSuccess, TFailure> union)
            where TSuccess : notnull
            where TFailure : notnull, new()
            =>
            // TODO: replace "() => new TFailure()"
            // with "() => default(TFailure)"
            // when TFailure became struct
            union.Or(() => new TFailure());
    }
}
