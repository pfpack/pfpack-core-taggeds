#nullable enable

namespace System
{
    internal static class ResultUnionExtensions
    {
        public static TaggedUnion<TSuccess, TFailure> OrInited<TSuccess, TFailure>(
            this in TaggedUnion<TSuccess, TFailure> union)
            where TSuccess : notnull
            where TFailure : notnull, new()
            =>
            union.Or(() => ResultUnion<TSuccess, TFailure>.Failure(new TFailure()));
    }
}
