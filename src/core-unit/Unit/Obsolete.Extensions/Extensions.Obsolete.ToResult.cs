#nullable enable

using System.Diagnostics.CodeAnalysis;

namespace System
{
    partial class UnitExtensions
    {
        [Obsolete(ObsoleteMessages.MethodNoLongerSupported, error: true)]
        [DoesNotReturn]
        public static TResult ToResult<TResult>(this Unit unit, TResult result)
            =>
            throw new NotImplementedException(ObsoleteMessages.MethodNoLongerSupported);
    }
}
