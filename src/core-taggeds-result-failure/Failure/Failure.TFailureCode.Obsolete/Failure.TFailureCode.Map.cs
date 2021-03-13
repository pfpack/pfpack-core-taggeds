#nullable enable

using System.Diagnostics.CodeAnalysis;

namespace System
{
    partial struct Failure<TFailureCode>
    {
        [Obsolete(ObsoleteMessages.Map, error: true)]
        [DoesNotReturn]
        public Failure<TResultFailureCode> Map<TResultFailureCode>(
            Func<TFailureCode, TResultFailureCode> mapFailureCode)
            where TResultFailureCode : struct
            =>
            throw new NotImplementedException(ObsoleteMessages.Map);
    }
}