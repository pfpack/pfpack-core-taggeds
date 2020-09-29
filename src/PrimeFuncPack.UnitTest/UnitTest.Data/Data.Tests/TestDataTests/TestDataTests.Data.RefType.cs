#nullable enable

using DeepEqual.Syntax;
using Xunit;

namespace PrimeFuncPack.UnitTest.Data.Tests
{
    partial class TestDataTests
    {
        [Fact]
        public void PlusFifteenIdRefType_ExpectRefTypeIdIsFifteen()
        {
            var actual = TestData.PlusFifteenIdRefType;

            var expected = new RefType
            {
                 Id = TestData.PlusFifteen
            };

            actual.ShouldDeepEqual(expected);
        }

        [Fact]
        public void PlusFifteenIdRefTypeTwoTimes_ExpectSameValues()
        {
            var first = TestData.PlusFifteenIdRefType;
            var second = TestData.PlusFifteenIdRefType;

            Assert.Same(first, second);
        }

        [Fact]
        public void ZeroIdRefType_ExpectRefTypeIdIsZero()
        {
            var actual = TestData.ZeroIdRefType;

            var expected = new RefType
            {
                Id = TestData.Zero
            };

            actual.ShouldDeepEqual(expected);
        }

        [Fact]
        public void ZeroIdRefTypeTwoTimes_ExpectSameValues()
        {
            var first = TestData.ZeroIdRefType;
            var second = TestData.ZeroIdRefType;

            Assert.Same(first, second);
        }

        [Fact]
        public void MinusFifteenIdRefType_ExpectRefTypeIdIsMinusFifteen()
        {
            var actual = TestData.MinusFifteenIdRefType;

            var expected = new RefType
            {
                Id = TestData.MinusFifteen
            };

            actual.ShouldDeepEqual(expected);
        }

        [Fact]
        public void MinusFifteenIdRefTypeTwoTimes_ExpectSameValues()
        {
            var first = TestData.MinusFifteenIdRefType;
            var second = TestData.MinusFifteenIdRefType;

            Assert.Same(first, second);
        }
    }
}
