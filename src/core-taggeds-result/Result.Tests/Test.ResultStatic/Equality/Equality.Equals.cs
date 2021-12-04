using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using System;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests
{
    partial class ResultStaticTest
    {
        [Test]
        public void Equals_ResultAIsDefaultAndResultBIsDefault_ExpectTrue()
        {
            var resultA = new Result<RefType, SomeError>();
            var resultB = default(Result<RefType, SomeError>);

            var actual = Result.Equals(resultA, resultB);
            Assert.True(actual);
        }

        [Test]
        public void Equals_ResultAIsSuccessAndResultBIsSuccessAndValuesAreNull_ExpectTrue()
        {
            var resultA = Result.Success<RefType?>(null).With<StructType>();
            Result<RefType?, StructType> resultB = null;

            var actual = Result.Equals(resultA, resultB);
            Assert.True(actual);
        }

        [Test]
        public void Equals_ResultAIsSuccessAndResultBIsSuccessAndValuesAreEqual_ExpectTrue()
        {
            var text = "Some new text.";
            var aValue = new SomeRecord
            {
                Text = text
            };
            var resultA = Result.Success(aValue).With<SomeError>();

            var bValue = new SomeRecord
            {
                Text = text
            };
            Result<SomeRecord, SomeError> resultB = bValue;

            var actual = Result.Equals(resultA, resultB);
            Assert.True(actual);
        }

        [Test]
        public void Equals_ResultAIsFailureAndResultBIsFailureAndValuesAreEqual_ExpectTrue()
        {
            var errorCode = MinusFifteen;
            var aValue = new SomeError(errorCode);
            Result<SomeRecord, SomeError> resultA = aValue;

            var bValue = new SomeError(errorCode);
            var resultB = Result.Failure(bValue).With<SomeRecord>();

            var actual = Result.Equals(resultA, resultB);
            Assert.True(actual);
        }

        [Test]
        public void Equals_ResultAIsFailureWithDefaultValueAndResultBIsDefault_ExpectTrue()
        {
            var resultA = default(Result<RefType, SomeError>);
            Result<RefType, SomeError> resultB = default(FailureBuilder<SomeError>);

            var actual = Result.Equals(resultA, resultB);
            Assert.True(actual);            
        }

        [Test]
        public void Equals_ResultAIsDefaultAndResultBIsFailureWithDefaultValue_ExpectTrue()
        {
            var resultA = Result<string, StructType>.Failure(default);
            var resultB = default(Result<string, StructType>);

            var actual = Result.Equals(resultA, resultB);
            Assert.True(actual);
        }

        [Test]
        public void Equals_ResultAIsSuccessAndResultBIsSuccessAndValuesAreNotEqual_ExpectFalse()
        {
            var aValue = new RefType();
            var resultA = Result<RefType, int>.Success(aValue);

            var bValue = new RefType();
            var resultB = Result<RefType, int>.Success(bValue);

            var actual = Result.Equals(resultA, resultB);
            Assert.False(actual);
        }

        [Test]
        public void Equals_ResultAIsFailureAndResultBIsFailureAndValuesAreNotEqual_ExpectFalse()
        {
            var text = "Some new text.";
            var aValue = new StructType
            {
                Text = text
            };
            var resultA = Result<object, StructType>.Failure(aValue);

            var bValue = new StructType
            {
                Text = text + ".."
            };
            var resultB = Result<object, StructType>.Failure(bValue);

            var actual = Result.Equals(resultA, resultB);
            Assert.False(actual);
        }

        [Test]
        public void Equals_ResultAIsSuccessAndResultBIsFailure_ExpectFalse()
        {
            var someValue = new SomeError(MinusFifteen);

            var resultA = Result.Success(someValue).With<SomeError>();
            var resultB = Result.Failure(someValue).With<SomeError>();

            var actual = Result.Equals(resultA, resultB);
            Assert.False(actual);
        }

        [Test]
        public void Equals_ResultAIsSuccessAndResultBIsDefault_ExpectFalse()
        {
            var resultA = Result<RefType, StructType>.Success(MinusFifteenIdRefType);
            var resultB = default(Result<RefType, StructType>);

            var actual = Result.Equals(resultA, resultB);
            Assert.False(actual);
        }

        [Test]
        public void Equals_ResultAIsFailureAndResultBIsSuccess_ExpectFalse()
        {
            var someValue = int.MaxValue;

            Result<int, int> resultA = Result.Failure(someValue);
            Result<int, int> resultB = Result.Success(someValue);

            var actual = Result.Equals(resultA, resultB);
            Assert.False(actual);
        }

        [Test]
        public void Equals_ResultAIsFailureWithNotDefaultValueAndResultBIsDefault_ExpectFalse()
        {
            var resultA = Result<RefType?, StructType>.Failure(SomeTextStructType);
            var resultB = default(Result<RefType?, StructType>);

            var actual = Result.Equals(resultA, resultB);
            Assert.False(actual);
        }

        [Test]
        public void Equals_ResultAIsDefaultAndResultBIsSuccess_ExpectFalse()
        {
            var resultA = default(Result<StructType, SomeError>);
            Result<StructType, SomeError> resultB = Result.Success<StructType>(default);

            var actual = Result.Equals(resultA, resultB);
            Assert.False(actual);
        }

        [Test]
        public void Equals_ResultAIsDefaultAndResultBIsFailureWithNotDefaultValue_ExpectFalse()
        {
            var resultA = default(Result<StructType, SomeError>);
            Result<StructType, SomeError> resultB = new SomeError(MinusFifteen);

            var actual = Result.Equals(resultA, resultB);
            Assert.False(actual);
        }
    }
}