using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using System;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests
{
    partial class ResultTest
    {
        [Test]
        public void EqualsOther_SourceIsDefaultAndOtherIsDefault_ExpectTrue()
        {
            var source = default(Result<RefType, StructType>);
            var other = new Result<RefType, StructType>();

            var actual = source.Equals(other);
            Assert.True(actual);
        }

        [Test]
        public void EqualsOther_SourceIsSuccessAndOtherIsSuccessAndValuesAreNull_ExpectTrue()
        {
            Result<SomeRecord?, StructType> source = null;
            var other = Result<SomeRecord?, StructType>.Success(null);

            var actual = source.Equals(other);
            Assert.True(actual);
        }

        [Test]
        public void EqualsOther_SourceIsSuccessAndOtherIsSuccessAndValuesAreEqual_ExpectTrue()
        {
            var text = "Some new text.";
            var sourceValue = new SomeRecord
            {
                Text = text
            };
            var source = Result<SomeRecord, SomeError>.Success(sourceValue);

            var otherValue = new SomeRecord
            {
                Text = text
            };
            Result<SomeRecord, SomeError> other = otherValue;

            var actual = source.Equals(other);
            Assert.True(actual);
        }

        [Test]
        public void EqualsOther_SourceIsFailureAndOtherIsFailureAndValuesAreEqual_ExpectTrue()
        {
            var errorCode = PlusFifteen;
            var sourceValue = new SomeError(errorCode);
            Result<RefType?, SomeError> source = sourceValue;

            var otherValue = new SomeError(errorCode);
            var other = Result<RefType?, SomeError>.Failure(otherValue);

            var actual = source.Equals(other);
            Assert.True(actual);
        }

        [Test]
        public void EqualsOther_SourceIsFailureWithDefaultValueAndOtherIsDefault_ExpectTrue()
        {
            var source = Result<RefType, StructType>.Failure(default);
            var other = default(Result<RefType, StructType>);

            var actual = source.Equals(other);
            Assert.True(actual);
        }

        [Test]
        public void EqualsOther_SourceIsDefaultAndOtherIsFailureWithDefaultValue_ExpectTrue()
        {
            var source = default(Result<RefType?, DateTime>);
            Result<RefType?, DateTime> other = default(DateTime);

            var actual = source.Equals(other);
            Assert.True(actual);
        }

        [Test]
        public void EqualsOther_SourceIsSuccessAndOtherIsSuccessAndValuesAreNotEqual_ExpectFalse()
        {
            var sourceValue = new object();
            var source = Result<object, StructType>.Success(sourceValue);

            var otherValue = new object();
            var other = Result<object, StructType>.Success(otherValue);

            var actual = source.Equals(other);
            Assert.False(actual);
        }

        [Test]
        public void EqualsOther_SourceIsFailureAndOtherIsFailureAndValuesAreNotEqual_ExpectFalse()
        {
            var text = "Some new text.";
            var sourceValue = new StructType
            {
                Text = text
            };
            var source = Result<RefType, StructType>.Failure(sourceValue);

            var otherValue = new StructType
            {
                Text = text + ".."
            };
            var other = Result<RefType, StructType>.Failure(otherValue);

            var actual = source.Equals(other);
            Assert.False(actual);
        }

        [Test]
        public void EqualsOther_SourceIsSuccessAndOtherIsFailure_ExpectFalse()
        {
            var sourceValue = new SomeError(PlusFifteen);

            var source = Result<SomeError, SomeError>.Success(sourceValue);
            var other = Result<SomeError, SomeError>.Failure(sourceValue);

            var actual = source.Equals(other);
            Assert.False(actual);
        }

        [Test]
        public void EqualsOther_SourceIsSuccessAndOtherIsDefault_ExpectFalse()
        {
            var source = Result<RefType?, StructType>.Success(null);
            var other = default(Result<RefType?, StructType>);

            var actual = source.Equals(other);
            Assert.False(actual);
        }

        [Test]
        public void EqualsOther_SourceIsFailureAndOtherIsSuccess_ExpectFalse()
        {
            var sourceValue = MinusFifteen;

            var source = Result<int, int>.Failure(sourceValue);
            var other = Result<int, int>.Success(sourceValue);

            var actual = source.Equals(other);
            Assert.False(actual);
        }

        [Test]
        public void EqualsOther_SourceIsFailureWithNotDefaultValueAndOtherIsDefault_ExpectFalse()
        {
            var source = Result<RefType, StructType>.Failure(SomeTextStructType);
            var other = default(Result<RefType, StructType>);

            var actual = source.Equals(other);
            Assert.False(actual);
        }

        [Test]
        public void EqualsOther_SourceIsDefaultAndOtherIsSuccess_ExpectFalse()
        {
            var source = default(Result<StructType, SomeError>);
            var other = Result<StructType, SomeError>.Success(default);

            var actual = source.Equals(other);
            Assert.False(actual);
        }

        [Test]
        public void EqualsOther_SourceIsDefaultAndOtherIsFailureWithNotDefaultValue_ExpectFalse()
        {
            var source = default(Result<StructType?, SomeError>);
            var other = Result<StructType?, SomeError>.Failure(new SomeError(PlusFifteen));

            var actual = source.Equals(other);
            Assert.False(actual);
        }
    }
}
