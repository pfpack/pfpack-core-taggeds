#nullable enable

namespace PrimeFuncPack
{
    public static class UnitExtensions
    {
        public static Unit ToUnit<TResult>(this TResult result) => Unit.FromResult(result);
    }
}
