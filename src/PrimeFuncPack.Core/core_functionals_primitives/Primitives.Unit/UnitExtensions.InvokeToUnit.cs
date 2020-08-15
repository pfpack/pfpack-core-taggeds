#nullable enable

namespace System
{
    partial class UnitExtensions
    {
        public static Unit InvokeToUnit(this Action action)
            =>
            Unit.InvokeAction(action);
    }
}
