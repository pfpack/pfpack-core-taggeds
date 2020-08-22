#nullable enable

using PrimeFuncPack.UnitTest.Data;
using Xunit;

namespace PrimeFuncPack.UnitTest.Tests
{
    partial class DataGeneratorTests
    {
        [Fact]
        public void GenerateByte_ExpectSomeByteValue()
        {
            var actual = DataGenerator.GenerateByte();
            _ = Assert.IsType<byte>(actual);
        }
    }
}
