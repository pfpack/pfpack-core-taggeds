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
        public void EqualsInequality_SourceIsDefaultAndOtherIsDefault_ExpectFalse()
        {
            var source = new FailureBuilder<StructType>();
            var other = default(FailureBuilder<StructType>);

            var actual = source != other;
            Assert.False(actual);
        }

        [Test]
        public void EqualsInequality_SourceIsDefaultAndOtherFailureIsDefault_ExpectFalse()
        {
            var source = default(FailureBuilder<StructType>);
            var other = Result.Failure(default(StructType));

            var actual = source != other;
            Assert.False(actual);
        }

        [Test]
        public void EqualsInequality_SourceFailureIsDefaultAndOtherIsDefault_ExpectFalse()
        {
            var source = Result.Failure(default(SomeError));
            var other = new FailureBuilder<SomeError>();

            var actual = source != other;
            Assert.False(actual);
        }

        [Test]
        public void EqualsInequality_SourceFailureIsDefaultAndOtherFailureIsDefault_ExpectFalse()
        {
            var source = Result.Failure(new StructType());
            var other = Result.Failure(new StructType());

            var actual = source != other;
            Assert.False(actual);
        }

        [Test]
        public void EqualsInequality_SourceFailureIsEqualOtherFailure_ExpectFalse()
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

            var actual = source != other;
            Assert.False(actual);
        }

        [Test]
        public void EqualsInequality_SourceIsDefaultAndOtherIsNotDefault_ExpectTrue()
        {
            var source = new FailureBuilder<SomeError>();
            var other = Result.Failure(new SomeError(int.MaxValue));

            var actual = source != other;
            Assert.True(actual);
        }

        [Test]
        public void EqualsInequality_SourceFailureIsNotEqualOtherFailure_ExpectTrue()
        {
            var sourceFailure = new SomeError(MinusFifteen);
            var source = Result.Failure(sourceFailure);

            var otherFailure = new SomeError(int.MaxValue);
            var other = Result.Failure(otherFailure);

            var actual = source != other;
            Assert.True(actual);
        }
    }
}