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
        public void EqualsObject_SourceIsDefaultAndObjectIsDefaultResultSameType_ExpectTrue()
        {
            var source = default(Result<RefType, StructType>);
            object? obj = new Result<RefType, StructType>();

            var actual = source.Equals(obj);
            Assert.True(actual);
        }

        [Test]
        public void EqualsObject_SourceIsSuccessAndObjectIsSuccessAndValuesAreEqual_ExpectTrue()
        {
            var sourceValue = PlusFifteenIdRefType;
            var source = Result<StructType, RefType>.Failure(sourceValue);

            var objValue = sourceValue;
            object? obj = Result<StructType, RefType>.Failure(objValue);

            var actual = source.Equals(obj);
            Assert.True(actual);
        }

        [Test]
        public void EqualsObject_SourceIsFailureAndObjectIsFailureAndValuesAreEqual_ExpectTrue()
        {
            var text = "Some new text.";
            var sourceValue = new StructType
            {
                Text = text
            };
            var source = Result<RefType, StructType>.Failure(sourceValue);

            var objValue = new StructType
            {
                Text = text
            };
            object? obj = Result<RefType, StructType>.Failure(objValue);

            var actual = source.Equals(obj);
            Assert.True(actual);
        }

        [Test]
        public void EqualsObject_SourceIsFailureWithDefaultValueAndObjectIsDefault_ExpectTrue()
        {
            var source = Result<RefType, StructType>.Failure(default);
            object? obj = default(Result<RefType, StructType>);

            var actual = source.Equals(obj);
            Assert.True(actual);
        }

        [Test]
        public void EqualsObject_SourceIsDefaultAndObjectIsFailureWithDefaultValue_ExpectTrue()
        {
            var source = default(Result<RefType, DateTime>);
            object? obj = Result<RefType, DateTime>.Failure(default);
            
            var actual = source.Equals(obj);
            Assert.True(actual);
        }

        [Test]
        public void EqualsObject_SourceIsSuccessAndObjectIsSuccessAndValuesAreNotEqual_ExpectFalse()
        {
            var sourceValue = new RefType();
            var source = Result<RefType, StructType>.Success(sourceValue);

            var objValue = new RefType();
            object? obj = Result<RefType, StructType>.Success(objValue);

            var actual = source.Equals(obj);
            Assert.False(actual);
        }

        [Test]
        public void EqualsObject_SourceIsFailureAndObjectIsFailureAndValuesAreNotEqual_ExpectFalse()
        {
            var text = "Some new text.";
            var sourceValue = new StructType
            {
                Text = text
            };
            var source = Result<RefType, StructType>.Failure(sourceValue);

            var objValue = new StructType
            {
                Text = text + ".."
            };
            object? obj = Result<RefType, StructType>.Failure(objValue);

            var actual = source.Equals(obj);
            Assert.False(actual);
        }

        [Test]
        public void EqualsObject_SourceIsSuccessAndObjectIsFailure_ExpectFalse()
        {
            var sourceValue = MinusFifteenIdRefType;

            var source = Result<RefType, RefType>.Success(sourceValue);
            object? obj = Result<RefType, RefType>.Failure(sourceValue);

            var actual = source.Equals(obj);
            Assert.False(actual);
        }

        [Test]
        public void EqualsObject_SourceIsSuccessAndObjectIsDefault_ExpectFalse()
        {
            var source = Result<StructType, RefType>.Success(default);
            object? obj = default(Result<StructType, RefType>);

            var actual = source.Equals(obj);
            Assert.False(actual);
        }

        [Test]
        public void EqualsObject_SourceIsFailureAndObjectIsSuccess_ExpectFalse()
        {
            var sourceValue = SomeTextStructType;

            var source = Result<StructType, StructType>.Failure(sourceValue);
            object? obj = Result<StructType, StructType>.Success(sourceValue);

            var actual = source.Equals(obj);
            Assert.False(actual);
        }

        [Test]
        public void EqualsObject_SourceIsFailureWithNotDefaultValueAndObjectIsDefault_ExpectFalse()
        {
            var source = Result<RefType, StructType>.Failure(SomeTextStructType);
            object? obj = default(Result<RefType, StructType>);

            var actual = source.Equals(obj);
            Assert.False(actual);
        }

        [Test]
        public void EqualsObject_SourceIsDefaultAndObjectIsSuccess_ExpectFalse()
        {
            var source = default(Result<int, RefType>);
            object? obj = Result<int, RefType>.Success(default);

            var actual = source.Equals(obj);
            Assert.False(actual);
        }

        [Test]
        public void EqualsObject_SourceIsDefaultAndObjectIsFailureWithNotDefaultValue_ExpectFalse()
        {
            var source = default(Result<StructType, RefType>);
            object? obj = Result<StructType, RefType>.Failure(ZeroIdRefType);

            var actual = source.Equals(obj);
            Assert.False(actual);
        }

        [Test]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.ResultTestSource))]
        public void EqualsObject_ObjectIsNull_ExpectFalse(
            in Result<RefType, StructType> source)
        {
            object? obj = null;
            var actual = source.Equals(obj);

            Assert.False(actual);
        }

        [Test]
        public void EqualsObject_SourceIsDefaultAndObjectIsNotResult_ExpectFalse()
        {
            var source = default(Result<RefType, StructType>);
            object? obj = new StructType();

            var actual = source.Equals(obj);
            Assert.False(actual);
        }

        [Test]
        public void EqualsObject_SourceIsDefaultAndObjectIsOtherTypeDefaultResult_ExpectFalse()
        {
            var source = default(Result<RefType, decimal>);
            object? obj = default(Result<RefType, int>);

            var actual = source.Equals(obj);
            Assert.False(actual);
        }

        [Test]
        public void EqualsObject_SourceIsSuccessAndObjectIsNotResult_ExpectFalse()
        {
            var sourceValue = SomeTextStructType;

            var source = Result<StructType, RefType>.Success(sourceValue);
            object? obj = sourceValue;

            var actual = source.Equals(obj);
            Assert.False(actual);
        }

        [Test]
        public void EqualsObject_SourceIsSuccessAndObjectIsOtherTypeSuccessResult_ExpectFalse()
        {
            var sourceValue = PlusFifteenIdRefType;

            var source = Result<RefType, StructType>.Success(sourceValue);
            object? obj = Result<RefType, int>.Success(sourceValue);

            var actual = source.Equals(obj);
            Assert.False(actual);
        }

        [Test]
        public void EqualsObject_SourceIsFailureAndObjectIsNotResult_ExpectFalse()
        {
            var sourceValue = ZeroIdRefType;

            var source = Result<StructType, RefType>.Failure(sourceValue);
            object? obj = sourceValue;

            var actual = source.Equals(obj);
            Assert.False(actual);
        }

        [Test]
        public void EqualsObject_SourceIsFailureAndObjectIsOtherTypeFailureResult_ExpectFalse()
        {
            var sourceValue = SomeTextStructType;

            var source = Result<int, StructType>.Failure(sourceValue);
            object? obj = Result<uint, StructType>.Failure(sourceValue);

            var actual = source.Equals(obj);
            Assert.False(actual);
        }
    }
}
