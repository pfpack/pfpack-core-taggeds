using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using System;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests
{
    partial class FailureBuilderTest
    {
        [Test]
        public void Equality_LeftIsDefaultAndRightIsDefault_ExpectTrue()
        {
            var left = new FailureBuilder<int>();
            var right = default(FailureBuilder<int>);

            var actual = left == right;
            Assert.True(actual);
        }

        [Test]
        public void Equality_LeftIsDefaultAndRightFailureIsDefault_ExpectTrue()
        {
            var left = new FailureBuilder<SomeError>();
            var right = Result.Failure(default(SomeError));

            var actual = left == right;
            Assert.True(actual);
        }

        [Test]
        public void Equality_LeftFailureIsDefaultAndRightIsDefault_ExpectTrue()
        {
            var left = Result.Failure(default(StructType));
            var right = default(FailureBuilder<StructType>);

            var actual = left == right;
            Assert.True(actual);
        }

        [Test]
        public void Equality_LeftFailureIsDefaultAndRightFailureIsDefault_ExpectTrue()
        {
            var left = Result.Failure(new StructType());
            var right = Result.Failure(default(StructType));

            var actual = left == right;
            Assert.True(actual);
        }

        [Test]
        public void Equality_LeftFailureIsEqualToRightFailure_ExpectTrue()
        {
            var text = "Some text value.";

            var leftFailure = new StructType
            {
                Text = text
            };
            var left = Result.Failure(leftFailure);

            var rightFailure = new StructType
            {
                Text = text
            };
            var right = Result.Failure(rightFailure);

            var actual = left == right;
            Assert.True(actual);
        }

        [Test]
        public void Equality_LeftIsDefaultAndRightIsNotDefault_ExpectFalse()
        {
            var left = new FailureBuilder<decimal>();
            var right = Result.Failure<decimal>(decimal.One);

            var actual = left == right;
            Assert.False(actual);
        }

        [Test]
        public void Equality_LeftFailureIsNotEqualToRightFailure_ExpectFalse()
        {
            var leftFailure = new SomeError(PlusFifteen);
            var left = Result.Failure(leftFailure);

            var rightFailure = new SomeError(MinusFifteen);
            var right = Result.Failure(rightFailure);

            var actual = left == right;
            Assert.False(actual);
        }
    }
}