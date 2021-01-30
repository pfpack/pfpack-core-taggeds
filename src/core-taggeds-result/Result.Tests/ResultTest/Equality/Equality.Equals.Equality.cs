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
        public void EqualsEquality_ResultAIsDefaultAndResultBIsDefault_ExpectTrue()
        {
            var resultA = default(Result<SomeRecord, StructType>);
            var resultB = new Result<SomeRecord, StructType>();

            var actual = resultA == resultB;
            Assert.True(actual);
        }

        [Test]
        public void EqualsEquality_ResultAIsSuccessAndResultBIsSuccessAndValuesAreNull_ExpectTrue()
        {
            var resultA = new Result<RefType?, StructType>(null);
            Result<RefType?, StructType> resultB = null;

            var actual = resultA == resultB;
            Assert.True(actual);
        }

        [Test]
        public void EqualsEquality_ResultAIsSuccessAndResultBIsSuccessAndValuesAreEqual_ExpectTrue()
        {
            var text = "Some new text.";
            var aValue = new SomeRecord
            {
                Text = text
            };
            var resultA = Result<SomeRecord, SomeError>.Success(aValue);

            var bValue = new SomeRecord
            {
                Text = text
            };
            var resultB = new Result<SomeRecord, SomeError>(bValue);

            var actual = resultA == resultB;
            Assert.True(actual);
        }

        [Test]
        public void EqualsEquality_ResultAIsFailureAndResultBIsFailureAndValuesAreEqual_ExpectTrue()
        {
            var errorCode = MinusFifteen;
            var aValue = new SomeError(errorCode);
            Result<RefType, SomeError> resultA = aValue;

            var bValue = new SomeError(errorCode);
            var resultB = new Result<RefType, SomeError>(bValue);

            var actual = resultA == resultB;
            Assert.True(actual);
        }

        [Test]
        public void EqualsEquality_ResultAIsFailureWithDefaultValueAndResultBIsDefault_ExpectTrue()
        {
            var resultA = default(Result<object, DateTime>);
            var resultB = new Result<object, DateTime>(default(DateTime));

            var actual = resultA == resultB;
            Assert.True(actual);            
        }

        [Test]
        public void EqualsEquality_ResultAIsDefaultAndResultBIsFailureWithDefaultValue_ExpectTrue()
        {
            var resultA = Result<RefType, StructType>.Failure(default);
            var resultB = new Result<RefType, StructType>();

            var actual = resultA == resultB;
            Assert.True(actual);
        }

        [Test]
        public void EqualsEquality_ResultAIsSuccessAndResultBIsSuccessAndValuesAreNotEqual_ExpectFalse()
        {
            var aValue = new RefType();
            var resultA = Result<RefType?, StructType>.Success(aValue);

            var bValue = new RefType();
            var resultB = Result<RefType?, StructType>.Success(bValue);

            var actual = resultA == resultB;
            Assert.False(actual);
        }

        [Test]
        public void EqualsEquality_ResultAIsFailureAndResultBIsFailureAndValuesAreNotEqual_ExpectFalse()
        {
            var text = "Some new text.";
            var aValue = new StructType
            {
                Text = text
            };
            var resultA = Result<SomeRecord, StructType>.Failure(aValue);

            var bValue = new StructType
            {
                Text = text + ".."
            };
            var resultB = Result<SomeRecord, StructType>.Failure(bValue);

            var actual = resultA == resultB;
            Assert.False(actual);
        }

        [Test]
        public void EqualsEquality_ResultAIsSuccessAndResultBIsFailure_ExpectFalse()
        {
            var someValue = SomeTextStructType;

            var resultA = Result<StructType, StructType>.Success(someValue);
            var resultB = Result<StructType, StructType>.Failure(someValue);

            var actual = resultA == resultB;
            Assert.False(actual);
        }

        [Test]
        public void EqualsEquality_ResultAIsSuccessAndResultBIsDefault_ExpectFalse()
        {
            var resultA = new Result<RefType, StructType>(ZeroIdRefType);
            var resultB = default(Result<RefType, StructType>);

            var actual = resultA == resultB;
            Assert.False(actual);
        }

        [Test]
        public void EqualsEquality_ResultAIsFailureAndResultBIsSuccess_ExpectFalse()
        {
            var someValue = MinusFifteen;

            var resultA = Result<int, int>.Failure(someValue);
            var resultB = Result<int, int>.Success(someValue);

            var actual = resultA == resultB;
            Assert.False(actual);
        }

        [Test]
        public void EqualsEquality_ResultAIsFailureWithNotDefaultValueAndResultBIsDefault_ExpectFalse()
        {
            var resultA = Result<RefType?, StructType>.Failure(SomeTextStructType);
            var resultB = default(Result<RefType?, StructType>);

            var actual = resultA == resultB;
            Assert.False(actual);
        }

        [Test]
        public void EqualsEquality_ResultAIsDefaultAndResultBIsSuccess_ExpectFalse()
        {
            var resultA = new Result<StructType, SomeError>();
            var resultB = new Result<StructType, SomeError>(default(StructType));

            var actual = resultA == resultB;
            Assert.False(actual);
        }

        [Test]
        public void EqualsEquality_ResultAIsDefaultAndResultBIsFailureWithNotDefaultValue_ExpectFalse()
        {
            var resultA = default(Result<StructType, SomeError>);
            var resultB = Result<StructType, SomeError>.Failure(new SomeError(PlusFifteen));

            var actual = resultA == resultB;
            Assert.False(actual);
        }
    }
}