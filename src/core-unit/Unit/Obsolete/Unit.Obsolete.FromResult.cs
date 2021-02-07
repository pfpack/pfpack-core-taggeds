#nullable enable

using System.Diagnostics.CodeAnalysis;

namespace System
{
    partial struct Unit
    {
        [Obsolete(ObsoleteMessages.MethodFromResultObsolete, error: true)]
        [DoesNotReturn]
        public static Unit FromResult<TResult>(TResult result)
            =>
            throw new NotImplementedException(ObsoleteMessages.MethodFromResultObsolete);
    }
}
