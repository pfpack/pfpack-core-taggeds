#nullable enable

using PrimeFuncPack.UnitTest.Moq;

namespace PrimeFuncPack.Core.Infrastructure.Tests.Stubs
{
    public sealed record StubType
    {
        private readonly IFunc<string?> stringFactory;

        public StubType(IFunc<string?> stringFactory)
            => this.stringFactory = stringFactory;

        public override string? ToString()
            => stringFactory.Invoke();
    }
}
