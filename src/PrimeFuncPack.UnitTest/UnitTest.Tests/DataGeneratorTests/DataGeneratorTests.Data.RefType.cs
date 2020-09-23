
#nullable enable

using PrimeFuncPack.UnitTest.Data;
using Xunit;

namespace PrimeFuncPack.UnitTest.Tests
{
    partial class DataGeneratorTests
    {
        [Fact]
        public void GenerateRefType_ExpectSomeRefType()
        {
            var actual = DataGenerator.GenerateRefType();
            _ = Assert.IsType<RefType>(actual);
        }
    }
}
