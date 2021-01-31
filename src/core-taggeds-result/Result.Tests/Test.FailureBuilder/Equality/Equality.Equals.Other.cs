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
        public void EqualsOther_SourceIsDefaultAndOtherIsDefault_ExpectTrue()
        {
            var source = default(FailureBuilder<StructType>);
            var other = new FailureBuilder<StructType>();

            var actual = source.Equals(other);
            Assert.True(actual);
        }

        [Test]
        public void EqualsOther_SourceIsDefaultAndOtherFailureIsDefault_ExpectTrue()
        {
            var source = default(FailureBuilder<StructType>);
            var other = Result.Failure(default(StructType));

            var actual = source.Equals(other);
            Assert.True(actual);
        }

        [Test]
        public void EqualsOther_SourceFailureIsDefaultAndOtherIsDefault_ExpectTrue()
        {
            var source = Result.Failure(default(StructType));
            var other = default(FailureBuilder<StructType>);

            var actual = source.Equals(other);
            Assert.True(actual);
        }

        [Test]
        public void EqualsOther_SourceFailureIsDefaultAndOtherFailureIsDefault_ExpectTrue()
        {
            var source = Result.Failure(default(SomeError));
            var other = Result.Failure(new SomeError());

            var actual = source.Equals(other);
            Assert.True(actual);
        }

        [Test]
        public void EqualsOther_SourceFailureIsEqualOtherFailure_ExpectTrue()
        {
            var errorCode = PlusFifteen;

            var sourceFailure = new SomeError(errorCode);
            var source = Result.Failure(sourceFailure);

            var otherFailure = new SomeError(errorCode);
            var other = Result.Failure(otherFailure);

            var actual = source.Equals(other);
            Assert.True(actual);
        }

        [Test]
        public void EqualsOther_SourceIsDefaultAndOtherIsNotDefault_ExpectFalse()
        {
            var source = new FailureBuilder<int>();
            var other = Result.Failure(PlusFifteen);

            var actual = source.Equals(other);
            Assert.False(actual);
        }

        [Test]
        public void EqualsOther_SourceFailureIsNotEqualOtherFailure_ExpectFalse()
        {
            var sourceFailure = new SomeError(PlusFifteen);
            var source = Result.Failure(sourceFailure);

            var otherFailure = new SomeError(MinusFifteen);
            var other = Result.Failure(otherFailure);

            var actual = source.Equals(other);
            Assert.False(actual);
        }
    }
}