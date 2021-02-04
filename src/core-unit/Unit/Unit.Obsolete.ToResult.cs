#nullable enable

using System.Diagnostics.CodeAnalysis;

namespace System
{
    partial struct Unit
    {
        [Obsolete(ObsoleteMessages.MethodNoLongerSupported, error: true)]
        [DoesNotReturn]
        public static TResult ToResult<TResult>(Unit unit, TResult result)
            =>
            throw new NotImplementedException(ObsoleteMessages.MethodNoLongerSupported);
    }
}
