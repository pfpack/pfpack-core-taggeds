#nullable enable

using System.Diagnostics.CodeAnalysis;

namespace System
{
    partial class TaggedUnionResultExtensions
    {
        [Obsolete(ObsoleteMessages.ToResult, error: true)]
        [DoesNotReturn]
        public static Result<TSuccess, TFailure> ToResult<TSuccess, TFailure>(this TaggedUnion<TSuccess, TFailure> union)
            where TSuccess : notnull
            where TFailure : struct
            =>
            throw new NotImplementedException(ObsoleteMessages.ToResult);
    }
}
