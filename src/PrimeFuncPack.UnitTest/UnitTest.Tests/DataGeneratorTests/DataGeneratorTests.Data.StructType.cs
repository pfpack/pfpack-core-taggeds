
#nullable enable

using PrimeFuncPack.UnitTest.Data;
using Xunit;

namespace PrimeFuncPack.UnitTest.Tests
{
    partial class DataGeneratorTests
    {
        [Fact]
        public void GenerateStructType_ExpectTextPropertyIsNotNull()
        {
            var actual = DataGenerator.GenerateStructType();

            var actualText = actual.Text;
            Assert.NotNull(actualText);

            var actualTextLength = actualText!.Length;
            Assert.True(actualTextLength >= 5);
        }
    }
}
