#nullable enable

namespace System
{
    partial class UnitExtensions
    {
        public static TResult ToResult<TResult>(this in Unit unit, in TResult result)
            =>
            Unit.ToResult(unit, result);
    }
}
