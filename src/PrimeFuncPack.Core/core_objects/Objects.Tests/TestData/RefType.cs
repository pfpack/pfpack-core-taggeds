#nullable enable

namespace PrimeFuncPack.Core.Objects.Tests.TestData
{
    internal sealed class RefType
    {
        public string? Text { get; set; }

        public override string? ToString()
            => Text;
    }
}
