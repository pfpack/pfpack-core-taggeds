#nullable enable

namespace System
{
    internal static class ResultUnion<TSuccess, TFailure>
        where TSuccess : notnull
        where TFailure : struct
    {
        public static TaggedUnion<TSuccess, TFailure> Success(in TSuccess success)
            =>
            TaggedUnion<TSuccess, TFailure>.First(success);

        public static TaggedUnion<TSuccess, TFailure> Failure(in TFailure failure)
            =>
            TaggedUnion<TSuccess, TFailure>.Second(failure);
    }
}
