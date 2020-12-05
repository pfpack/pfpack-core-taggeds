#nullable enable

namespace System
{
    partial class UnitExtensions
    {
        public static TResult ToResult<TResult>(this Unit unit, TResult result)
            =>
            Unit.ToResult(unit, result);
    }
}
