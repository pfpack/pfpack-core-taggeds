#nullable enable

namespace PrimeFuncPack.Core.Tests
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
