#nullable enable

using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using System;
using System.Threading.Tasks;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests
{
    partial class ResultTest
    {
        [Test]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureDefaultTestSource))]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureSomeTextStructTypeTestSource))]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessNullTestSource))]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessMinusFifteenIdRefTypeTestSource))]
        public void ForwardValueAsyncMapFailure_NextFactoryAsyncIsNull_ExpectArgumentNullException(
            Result<RefType, StructType> source)
        {
            var mappedFailure = new SomeError(PlusFifteen);

            var actualException = Assert.ThrowsAsync<ArgumentNullException>(
                async () => _ = await source.ForwardValueAsync<SomeRecord, SomeError>(null!,  _ => mappedFailure));

            Assert.AreEqual("nextFactoryAsync", actualException!.ParamName);
        }

        [Test]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureDefaultTestSource))]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureSomeTextStructTypeTestSource))]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessNullTestSource))]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessPlusFifteenIdRefTypeTestSource))]
        public void ForwardValueAsyncMapFailure_MapFailureIsNull_ExpectArgumentNullException(
            Result<RefType, StructType> source)
        {
            var next = new Result<SomeRecord, SomeError>(new SomeRecord());

            var actualException = Assert.ThrowsAsync<ArgumentNullException>(
                async () => _ = await source.ForwardValueAsync(_ => ValueTask.FromResult(next), null!));

            Assert.AreEqual("mapFailure", actualException!.ParamName);
        }

        [Test]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureDefaultTestSource))]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureSomeTextStructTypeTestSource))]
        public async Task ForwardValueAsyncMapFailure_SourceIsDefaultOrFailure_ExpectResultOfMappedFailure(
            Result<RefType, StructType> source)
        {
            var next = new Result<SomeRecord, SomeError>(new SomeError(MinusFifteen));
            var mappedFailure = new SomeError(int.MaxValue);

            var actual = await source.ForwardValueAsync(_ => ValueTask.FromResult(next), _ => mappedFailure);
            var expected = new Result<SomeRecord, SomeError>(mappedFailure);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessNullTestSource))]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessMinusFifteenIdRefTypeTestSource))]
        public async Task ForwardValueAsyncMapFailure_SourceIsSuccessAndNextIsDefault_ExpectDefault(
            Result<RefType, StructType> source)
        {
            var next = default(Result<string, SomeError>);
            var mappedFailure = new SomeError(PlusFifteen);

            var actual = await source.ForwardValueAsync(_ => ValueTask.FromResult(next), _ => mappedFailure);
            Assert.AreEqual(next, actual);
        }

        [Test]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessNullTestSource))]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessMinusFifteenIdRefTypeTestSource))]
        public async Task ForwardValueAsyncMapFailure_SourceIsSuccessAndNextIsSuccess_ExpectNext(
            Result<RefType, StructType> source)
        {
            Result<RefType, SomeError> next = Result.Success(PlusFifteenIdRefType);
            var mappedFailure = new SomeError(int.MaxValue);

            var actual = await source.ForwardValueAsync(_ => ValueTask.FromResult(next), _ => mappedFailure);
            Assert.AreEqual(next, actual);
        }

        [Test]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessNullTestSource))]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessMinusFifteenIdRefTypeTestSource))]
        public async Task ForwardValueAsyncMapFailure_SourceIsSuccessAndNextIsFailure_ExpectNext(
            Result<RefType, StructType> source)
        {
            Result<SomeRecord, SomeError> next = Result.Failure(new SomeError(int.MinValue));
            var mappedFailure = new SomeError(PlusFifteen);

            var actual = await source.ForwardValueAsync(_ => ValueTask.FromResult(next), _ => mappedFailure);
            Assert.AreEqual(next, actual);
        }
    }
}