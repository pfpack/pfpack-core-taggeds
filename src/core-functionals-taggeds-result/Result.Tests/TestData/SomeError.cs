#nullable enable

namespace PrimeFuncPack.Core.Functionals.Taggeds.Tests
{
    internal readonly struct SomeError
    {
        public SomeError(
            int errorCode)
            =>
            ErrorCode = errorCode;

        public int ErrorCode { get; }
    }
}
