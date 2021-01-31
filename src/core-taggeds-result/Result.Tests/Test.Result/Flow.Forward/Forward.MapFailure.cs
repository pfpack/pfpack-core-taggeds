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
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureDefaultTestSource))]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureSomeTextStructTypeTestSource))]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessNullTestSource))]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessPlusFifteenIdRefTypeTestSource))]
        public void ForwardMapFailure_NextFactoryIsNull_ExpectArgumentNullException(
            Result<RefType, StructType> source)
        {
            var mappedFailure = new SomeError(MinusFifteen);

            var actualException = Assert.Throws<ArgumentNullException>(
                () => _ = source.Forward<SomeRecord, SomeError>(null!, _ => mappedFailure));

            Assert.AreEqual("nextFactory", actualException!.ParamName);
        }

        [Test]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureDefaultTestSource))]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureSomeTextStructTypeTestSource))]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessNullTestSource))]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessMinusFifteenIdRefTypeTestSource))]
        public void ForwardMapFailure_MapFailureIsNull_ExpectArgumentNullException(
            Result<RefType, StructType> source)
        {
            var next = new Result<int, SomeError>(PlusFifteen);

            var actualException = Assert.Throws<ArgumentNullException>(
                () => _ = source.Forward(_ => next, null!));

            Assert.AreEqual("mapFailure", actualException!.ParamName);
        }

        [Test]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureDefaultTestSource))]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureSomeTextStructTypeTestSource))]
        public void ForwardMapFailure_SourceIsDefaultOrFailure_ExpectResultOfMappedFailure(
            Result<RefType, StructType> source)
        {
            Result<SomeRecord, SomeError> next = new SomeRecord();
            var mappedFailure = new SomeError(MinusFifteen);

            var actual = source.Forward(_ => next, _ => mappedFailure);
            var expected = new Result<SomeRecord, SomeError>(mappedFailure);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessNullTestSource))]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessPlusFifteenIdRefTypeTestSource))]
        public void ForwardMapFailure_SourceIsSuccessAndNextIsDefault_ExpectDefault(
            Result<RefType, StructType> source)
        {
            var next = new Result<string, int>();
            var mappedFailure = MinusFifteen;

            var actual = source.Forward(_ => next, _ => mappedFailure);
            Assert.AreEqual(next, actual);
        }

        [Test]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessNullTestSource))]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessMinusFifteenIdRefTypeTestSource))]
        public void ForwardMapFailure_SourceIsSuccessAndNextIsSuccess_ExpectNext(
            Result<RefType, StructType> source)
        {
            var next = Result.Success(PlusFifteenIdRefType).With<decimal>();
            var mappedFailure = decimal.One;

            var actual = source.Forward(_ => next, _ => mappedFailure);
            Assert.AreEqual(next, actual);
        }

        [Test]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessNullTestSource))]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessPlusFifteenIdRefTypeTestSource))]
        public void ForwardMapFailure_SourceIsSuccessAndNextIsFailure_ExpectNext(
            Result<RefType, StructType> source)
        {
            Result<SomeRecord, SomeError> next = new SomeError(MinusFifteen);
            var mappedFailure = new SomeError(int.MaxValue);

            var actual = source.Forward(_ => next, _ => mappedFailure);
            Assert.AreEqual(next, actual);
        }
    }
}