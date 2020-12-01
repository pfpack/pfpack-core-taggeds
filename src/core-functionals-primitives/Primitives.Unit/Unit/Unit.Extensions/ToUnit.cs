#nullable enable

namespace System
{
    partial class UnitExtensions
    {
        public static Unit ToUnit<TResult>(this TResult result)
            =>
            Unit.FromResult(result);
    }
}
