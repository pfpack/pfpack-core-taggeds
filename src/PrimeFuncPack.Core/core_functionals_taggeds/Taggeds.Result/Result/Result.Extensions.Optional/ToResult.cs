#nullable enable

using System.Diagnostics.CodeAnalysis;

namespace System
{
    partial class OptionalResultExtensions
    {
        [Obsolete(ObsoleteMessages.ToResult, error: true)]
        [DoesNotReturn]
        public static Result<T, Unit> ToResult<T>(this Optional<T> optional) where T : notnull
            =>
            throw new NotImplementedException(ObsoleteMessages.ToResult);
    }
}
