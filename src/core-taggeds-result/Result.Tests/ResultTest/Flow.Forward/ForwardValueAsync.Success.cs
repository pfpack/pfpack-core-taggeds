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
        public void ForwardValueAsync_NextFactoryIsNull_ExpectArgumentNullException(
            Result<RefType, StructType> source)
        {            
            var actualException = Assert.ThrowsAsync<ArgumentNullException>(
                async () => _ = await source.ForwardValueAsync<object>(null!));

            Assert.AreEqual("nextFactoryAsync", actualException!.ParamName);
        }

        [Test]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureDefaultTestSource))]
        public async Task ForwardValueAsync_SourceIsDefault_ExpectDefault(
            Result<RefType, StructType> source)
        {
            var next = Result.Success<object>(new object()).With<StructType>();
            var actual = await source.ForwardValueAsync(_ => ValueTask.FromResult(next));

            var expected = default(Result<object, StructType>);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureSomeTextStructTypeTestSource))]
        public async Task ForwardValueAsync_SourceIsFailure_ExpectResultOfSourceFailure(
            Result<RefType, StructType> source)
        {
            var next = new Result<string, StructType>(SomeString);
            var actual = await source.ForwardValueAsync(_ => ValueTask.FromResult(next));

            var expected = Result.Failure(SomeTextStructType).With<string>();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessNullTestSource))]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessPlusFifteenIdRefTypeTestSource))]
        public async Task ForwardValueAsync_SourceIsSuccessAndNextIsDefault_ExpectDefault(
            Result<RefType, StructType> source)
        {
            var next = default(Result<SomeRecord, StructType>);
            var actual = await source.ForwardValueAsync(_ => ValueTask.FromResult(next));

            Assert.AreEqual(next, actual);
        }

        [Test]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessNullTestSource))]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessPlusFifteenIdRefTypeTestSource))]
        public async Task ForwardValueAsync_SourceIsSuccessAndNextIsSuccess_ExpectNext(
            Result<RefType, StructType> source)
        {
            var next = new Result<int, StructType>(MinusFifteen);
            var actual = await source.ForwardValueAsync(_ => ValueTask.FromResult(next));

            Assert.AreEqual(next, actual);
        }

        [Test]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessNullTestSource))]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessMinusFifteenIdRefTypeTestSource))]
        public async Task ForwardValueAsync_SourceIsSuccessAndNextIsFailure_ExpectNext(
            Result<RefType, StructType> source)
        {
            var next = new Result<SomeRecord, StructType>(SomeTextStructType);
            var actual = await source.ForwardValueAsync(_ => ValueTask.FromResult(next));

            Assert.AreEqual(next, actual);
        }
    }
}