#nullable enable

namespace System
{
    public static class UnitExtensions
    {
        public static Unit ToUnit<TResult>(this TResult result) => Unit.FromResult(result);
    }
}
