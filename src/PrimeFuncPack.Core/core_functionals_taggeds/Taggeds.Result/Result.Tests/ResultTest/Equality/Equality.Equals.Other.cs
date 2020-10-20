#nullable enable

using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using System;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Functionals.Taggeds.Tests
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
        public void EqualsOther_SourceIsSuccessAndOtherIsSuccessAndValuesAreEqual_ExpectTrue()
        {
            var text = "Some new text.";
            var sourceValue = new StructType
            {
                Text = text
            };
            var source = Result<StructType, object>.Success(sourceValue);

            var otherValue = new StructType
            {
                Text = text
            };
            Result<StructType, object> other = otherValue;

            var actual = source.Equals(other);
            Assert.True(actual);
        }

        [Test]
        public void EqualsOther_SourceIsFailureAndOtherIsFailureAndValuesAreEqual_ExpectTrue()
        {
            var sourceValue = new object();
            Result<RefType, object> source = sourceValue;

            var otherValue = sourceValue;
            var other = Result<RefType, object>.Failure(otherValue);

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
            var source = default(Result<RefType, DateTime>);
            Result<RefType, DateTime> other = default(DateTime);

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
            var sourceValue = SomeTextStructType;

            var source = Result<StructType, StructType>.Success(sourceValue);
            var other = Result<StructType, StructType>.Failure(sourceValue);

            var actual = source.Equals(other);
            Assert.False(actual);
        }

        [Test]
        public void EqualsOther_SourceIsSuccessAndOtherIsDefault_ExpectFalse()
        {
            var source = Result<RefType, StructType>.Success(ZeroIdRefType);
            var other = default(Result<RefType, StructType>);

            var actual = source.Equals(other);
            Assert.False(actual);
        }

        [Test]
        public void EqualsOther_SourceIsFailureAndOtherIsSuccess_ExpectFalse()
        {
            var sourceValue = PlusFifteenIdRefType;

            var source = Result<RefType, RefType>.Failure(sourceValue);
            var other = Result<RefType, RefType>.Success(sourceValue);

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
            var source = default(Result<StructType, RefType>);
            var other = Result<StructType, RefType>.Success(default);

            var actual = source.Equals(other);
            Assert.False(actual);
        }

        [Test]
        public void EqualsOther_SourceIsDefaultAndOtherIsFailureWithNotDefaultValue_ExpectFalse()
        {
            var source = default(Result<StructType, RefType>);
            var other = Result<StructType, RefType>.Failure(new RefType());

            var actual = source.Equals(other);
            Assert.False(actual);
        }
    }
}
