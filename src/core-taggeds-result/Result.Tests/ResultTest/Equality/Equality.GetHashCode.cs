#nullable enable

using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using System;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests
{
    partial class ResultTest
    {
        [Test]
        public void GetHashCode_SourceIsDefaultAndOtherIsDefault_ExpectHashCodesAreEqual()
        {
            var source = default(Result<StructType, SomeError>);
            var other = default(Result<StructType, SomeError>);

            var sourceHashCode = source.GetHashCode();
            var otherHashCode = other.GetHashCode();

            Assert.AreEqual(sourceHashCode, otherHashCode);
        }

        [Test]
        public void GetHashCode_SourceIsSuccessAndOtherIsSuccessAndValuesAreEqual_ExpectHashCodesAreEqual()
        {
            var text = "Some new text.";
            var sourceValue = new SomeRecord
            {
                Text = text
            };
            var source = Result<SomeRecord, int>.Success(sourceValue);

            var otherValue = new SomeRecord
            {
                Text = text
            };
            Result<SomeRecord, int> other = otherValue;

            var sourceHashCode = source.GetHashCode();
            var otherHashCode = other.GetHashCode();

            Assert.AreEqual(sourceHashCode, otherHashCode);
        }

        [Test]
        public void GetHashCode_SourceIsFailureAndOtherIsFailureAndValuesAreEqual_ExpectHashCodesAreEqual()
        {
            var sourceValue = SomeTextStructType;
            Result<RefType, StructType> source = sourceValue;

            var otherValue = sourceValue;
            var other = Result<RefType, StructType>.Failure(otherValue);

            var sourceHashCode = source.GetHashCode();
            var otherHashCode = other.GetHashCode();

            Assert.AreEqual(sourceHashCode, otherHashCode);
        }

        [Test]
        public void GetHashCode_SourceIsDefaultAndOtherIsDefaultButTypesAreNotSame_ExpectHashCodesAreNotEqual()
        {
            var source = new Result<int, SomeError>();
            var other = default(Result<decimal, SomeError>);

            var sourceHashCode = source.GetHashCode();
            var otherHashCode = other.GetHashCode();

            Assert.AreNotEqual(sourceHashCode, otherHashCode);
        }

        [Test]
        public void GetHashCode_SourceIsSuccessAndOtherIsSuccessAndValuesAreEqualButTypesAreNotSame_ExpectHashCodesAreNotEqual()
        {
            var text = "Some new text.";
            var sourceValue = new StructType
            {
                Text = text
            };
            var source = Result<StructType, SomeError>.Success(sourceValue);

            var otherValue = new StructType
            {
                Text = text
            };
            Result<StructType, int> other = otherValue;

            var sourceHashCode = source.GetHashCode();
            var otherHashCode = other.GetHashCode();

            Assert.AreNotEqual(sourceHashCode, otherHashCode);
        }

        [Test]
        public void GetHashCode_SourceIsFailureAndOtherIsFailureAndValuesAreEqualButTypesAreNotSame_ExpectHashCodesAreNotEqual()
        {
            var sourceValue = new SomeError(int.MaxValue);
            var source = Result<object, SomeError>.Failure(sourceValue);

            var otherValue = sourceValue;
            var other = Result<RefType, SomeError>.Failure(otherValue);

            var sourceHashCode = source.GetHashCode();
            var otherHashCode = other.GetHashCode();

            Assert.AreNotEqual(sourceHashCode, otherHashCode);
        }

        [Test]
        public void GetHashCode_SourceIsFailureWithDefaultValueAndOtherIsDefault_ExpectHashCodesAreEqual()
        {
            var source = Result<RefType, StructType>.Failure(default);
            var other = default(Result<RefType, StructType>);

            var sourceHashCode = source.GetHashCode();
            var otherHashCode = other.GetHashCode();

            Assert.AreEqual(sourceHashCode, otherHashCode);
        }

        [Test]
        public void GetHashCode_SourceIsDefaultAndOtherIsFailureWithDefaultValue_ExpectHashCodesAreEqual()
        {
            Result<RefType, StructType> source = default(StructType);
            var other = default(Result<RefType, StructType>);

            var sourceHashCode = source.GetHashCode();
            var otherHashCode = other.GetHashCode();

            Assert.AreEqual(sourceHashCode, otherHashCode);
        }

        [Test]
        public void GetHashCode_SourceIsSuccessAndOtherIsSuccessAndValuesAreNotEqual_ExpectHashCodesAreNotEqual()
        {
            var sourceValue = new SomeError(PlusFifteen);
            var source = Result<object, SomeError>.Success(sourceValue);

            var otherValue = new SomeError(MinusFifteen);
            var other = Result<object, SomeError>.Success(otherValue);

            var sourceHashCode = source.GetHashCode();
            var otherHashCode = other.GetHashCode();

            Assert.AreNotEqual(sourceHashCode, otherHashCode);
        }

        [Test]
        public void GetHashCode_SourceIsFailureAndOtherIsFailureAndValuesAreNotEqual_ExpectHashCodesAreNotEqual()
        {
            var sourceValue = new DateTime(2015, 11, 15);
            var source = Result<RefType, DateTime>.Failure(sourceValue);

            var otherValue = sourceValue.AddYears(1);
            var other = Result<RefType, DateTime>.Failure(otherValue);

            var sourceHashCode = source.GetHashCode();
            var otherHashCode = other.GetHashCode();

            Assert.AreNotEqual(sourceHashCode, otherHashCode);
        }

        [Test]
        public void GetHashCode_SourceIsSuccessAndOtherIsFailure_ExpectHashCodesAreNotEqual()
        {
            var sourceValue = SomeTextStructType;

            var source = Result<StructType, StructType>.Success(sourceValue);
            var other = Result<StructType, StructType>.Failure(sourceValue);

            var sourceHashCode = source.GetHashCode();
            var otherHashCode = other.GetHashCode();

            Assert.AreNotEqual(sourceHashCode, otherHashCode);
        }

        [Test]
        public void GetHashCode_SourceIsSuccessAndOtherIsDefault_ExpectHashCodesAreNotEqual()
        {
            var source = Result<StructType, SomeError>.Success(default);
            var other = default(Result<StructType, SomeError>);

            var sourceHashCode = source.GetHashCode();
            var otherHashCode = other.GetHashCode();

            Assert.AreNotEqual(sourceHashCode, otherHashCode);
        }

        [Test]
        public void GetHashCode_SourceIsFailureAndOtherIsSuccess_ExpectHashCodesAreNotEqual()
        {
            var sourceValue = new SomeError(PlusFifteen);

            var source = Result<SomeError, SomeError>.Failure(sourceValue);
            var other = Result<SomeError, SomeError>.Success(sourceValue);

            var sourceHashCode = source.GetHashCode();
            var otherHashCode = other.GetHashCode();

            Assert.AreNotEqual(sourceHashCode, otherHashCode);
        }

        [Test]
        public void GetHashCode_SourceIsFailureWithNotDefaultValueAndOtherIsDefault_ExpectHashCodesAreNotEqual()
        {
            var source = Result<RefType, StructType>.Failure(SomeTextStructType);
            var other = default(Result<RefType, StructType>);

            var sourceHashCode = source.GetHashCode();
            var otherHashCode = other.GetHashCode();

            Assert.AreNotEqual(sourceHashCode, otherHashCode);
        }

        [Test]
        public void GetHashCode_SourceIsDefaultAndOtherIsSuccess_ExpectHashCodesAreNotEqual()
        {
            var source = default(Result<StructType, SomeError>);
            var other = Result<StructType, SomeError>.Success(default);

            var sourceHashCode = source.GetHashCode();
            var otherHashCode = other.GetHashCode();

            Assert.AreNotEqual(sourceHashCode, otherHashCode);
        }

        [Test]
        public void GetHashCode_SourceIsDefaultAndOtherIsFailureWithNotDefaultValue_ExpectHashCodesAreNotEqual()
        {
            var source = default(Result<StructType, SomeError>);
            var other = Result<StructType, SomeError>.Failure(new SomeError(MinusFifteen));

            var sourceHashCode = source.GetHashCode();
            var otherHashCode = other.GetHashCode();

            Assert.AreNotEqual(sourceHashCode, otherHashCode);
        }
    }
}
