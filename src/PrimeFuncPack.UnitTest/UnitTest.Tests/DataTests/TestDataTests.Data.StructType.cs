#nullable enable

using Xunit;

namespace PrimeFuncPack.UnitTest.Tests
{
    partial class TestDataTests
    {
        [Fact]
        public void SomeTextStructType_ExpectStructTypeTextIsSomeString()
        {
            var actual = TestData.SomeTextStructType;

            var expected = new StructType
            {
                Text = TestData.SomeString
            };

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void NullTextStructType_ExpectDefaultStructTypeValue()
        {
            var actual = TestData.NullTextStructType;

            var expected = default(StructType);

            Assert.Equal(expected, actual);
        }
    }
}
