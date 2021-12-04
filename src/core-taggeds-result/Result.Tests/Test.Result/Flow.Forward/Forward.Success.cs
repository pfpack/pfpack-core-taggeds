using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using System;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests
{
    partial class ResultTest
    {
        [Test]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureDefaultTestSource))]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureSomeTextStructTypeTestSource))]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessNullTestSource))]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessPlusFifteenIdRefTypeTestSource))]
        public void Forward_NextFactoryIsNull_ExpectArgumentNullException(
            Result<RefType, StructType> source)
        {            
            var actualException = Assert.Throws<ArgumentNullException>(
                () => _ = source.Forward<SomeRecord>(null!));

            Assert.AreEqual("nextFactory", actualException!.ParamName);
        }

        [Test]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureDefaultTestSource))]
        public void Forward_SourceIsDefault_ExpectDefault(
            Result<RefType, StructType> source)
        {
            Result<SomeRecord, StructType> next = new SomeRecord();
            var actual = source.Forward(_ => next);

            var expected = default(Result<SomeRecord, StructType>);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureSomeTextStructTypeTestSource))]
        public void Forward_SourceIsFailure_ExpectResultOfSourceFailure(
            Result<RefType, StructType> source)
        {
            var next = Result<int, StructType>.Success(PlusFifteen);
            var actual = source.Forward(_ => next);

            var expected = new Result<int, StructType>(SomeTextStructType);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessNullTestSource))]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessMinusFifteenIdRefTypeTestSource))]
        public void Forward_SourceIsSuccessAndNextIsDefault_ExpectDefault(
            Result<RefType, StructType> source)
        {
            var next = new Result<int, StructType>();
            var actual = source.Forward(_ => next);

            Assert.AreEqual(next, actual);
        }

        [Test]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessNullTestSource))]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessMinusFifteenIdRefTypeTestSource))]
        public void Forward_SourceIsSuccessAndNextIsSuccess_ExpectNext(
            Result<RefType, StructType> source)
        {
            var next = Result.Success(PlusFifteenIdRefType).With<StructType>();
            var actual = source.Forward(_ => next);

            Assert.AreEqual(next, actual);
        }

        [Test]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessNullTestSource))]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessMinusFifteenIdRefTypeTestSource))]
        public void Forward_SourceIsSuccessAndNextIsFailure_ExpectNext(
            Result<RefType, StructType> source)
        {
            var next = new Result<SomeRecord?, StructType>(SomeTextStructType);
            var actual = source.Forward(_ => next);

            Assert.AreEqual(next, actual);
        }
    }
}