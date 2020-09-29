#nullable enable

using Xunit;

namespace PrimeFuncPack.UnitTest.Data.Tests
{
    partial class TestDataTests
    {
        [Fact]
        public void PlusFifteen_ExpectFifteenIntegerValue()
        {
            var actual = TestData.PlusFifteen;
            Assert.Equal(15, actual);
        }

        [Fact]
        public void Zero_ExpectZeroIntegerValue()
        {
            var actual = TestData.Zero;
            Assert.Equal(0, actual);
        }

        [Fact]
        public void MinusFifteen_ExpectMinusFifteenIntegerValue()
        {
            var actual = TestData.MinusFifteen;
            Assert.Equal(-15, actual);
        }
    }
}
