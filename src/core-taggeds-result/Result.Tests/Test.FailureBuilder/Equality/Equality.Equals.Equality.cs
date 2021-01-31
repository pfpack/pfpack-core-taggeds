#nullable enable

using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using System;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests
{
    partial class FailureBuilderTest
    {
        [Test]
        public void EqualsEquality_SourceIsDefaultAndOtherIsDefault_ExpectTrue()
        {
            var source = new FailureBuilder<int>();
            var other = default(FailureBuilder<int>);

            var actual = source == other;
            Assert.True(actual);
        }

        [Test]
        public void EqualsEquality_SourceIsDefaultAndOtherFailureIsDefault_ExpectTrue()
        {
            var source = new FailureBuilder<SomeError>();
            var other = Result.Failure(default(SomeError));

            var actual = source == other;
            Assert.True(actual);
        }

        [Test]
        public void EqualsEquality_SourceFailureIsDefaultAndOtherIsDefault_ExpectTrue()
        {
            var source = Result.Failure(default(StructType));
            var other = default(FailureBuilder<StructType>);

            var actual = source == other;
            Assert.True(actual);
        }

        [Test]
        public void EqualsEquality_SourceFailureIsDefaultAndOtherFailureIsDefault_ExpectTrue()
        {
            var source = Result.Failure(new StructType());
            var other = Result.Failure(default(StructType));

            var actual = source == other;
            Assert.True(actual);
        }

        [Test]
        public void EqualsEquality_SourceFailureIsEqualOtherFailure_ExpectTrue()
        {
            var text = "Some text value.";

            var sourceFailure = new StructType
            {
                Text = text
            };
            var source = Result.Failure(sourceFailure);

            var otherFailure = new StructType
            {
                Text = text
            };
            var other = Result.Failure(otherFailure);

            var actual = source == other;
            Assert.True(actual);
        }

        [Test]
        public void EqualsEquality_SourceIsDefaultAndOtherIsNotDefault_ExpectFalse()
        {
            var source = new FailureBuilder<decimal>();
            var other = Result.Failure<decimal>(decimal.One);

            var actual = source == other;
            Assert.False(actual);
        }

        [Test]
        public void EqualsEquality_SourceFailureIsNotEqualOtherFailure_ExpectFalse()
        {
            var sourceFailure = new SomeError(PlusFifteen);
            var source = Result.Failure(sourceFailure);

            var otherFailure = new SomeError(MinusFifteen);
            var other = Result.Failure(otherFailure);

            var actual = source == other;
            Assert.False(actual);
        }
    }
}