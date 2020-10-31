#nullable enable

namespace PrimeFuncPack.Core.Functionals.Taggeds.Tests
{
    internal readonly struct SomeError
    {
        public SomeError(
            in int errorCode)
            =>
            ErrorCode = errorCode;

        public int ErrorCode { get; }
    }
}
