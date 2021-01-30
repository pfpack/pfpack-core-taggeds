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
        public void FoldAsync_MapSuccessAsyncIsNull_ExpectArgumentNullException(
            Result<RefType, StructType> source)
        {
            var failureResult = new SomeRecord
            {
                Text = SomeString
            };

            var actualException = Assert.ThrowsAsync<ArgumentNullException>(
                async () => _ = await source.FoldAsync(null!, _ => Task.FromResult(failureResult)));

            Assert.AreEqual("mapSuccessAsync", actualException!.ParamName);
        }

        [Test]        
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureDefaultTestSource))]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureSomeTextStructTypeTestSource))]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessNullTestSource))]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessPlusFifteenIdRefTypeTestSource))]
        public void FoldAsync_MapFailureAsyncIsNull_ExpectArgumentNullException(
            Result<RefType, StructType> source)
        {
            var successResult = SomeString;

            var actualException = Assert.Throws<ArgumentNullException>(
                () => _ = source.FoldAsync(_ => Task.FromResult(successResult), null!));

            Assert.AreEqual("mapFailureAsync", actualException!.ParamName);
        }

        [Test]        
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessNullTestSource))]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessPlusFifteenIdRefTypeTestSource))]
        public async Task FoldAsync_SourceIsSuccess_ExpectResultOfMapSuccess(
            Result<RefType, StructType> source)
        {
            var successResult = (string?)null;
            var failureResult = SomeString;

            var actual = await source.FoldAsync(
                _ => Task.FromResult(successResult),
                _ => Task.FromResult<string?>(failureResult));

            Assert.AreEqual(successResult, actual);
        }

        [Test]        
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureDefaultTestSource))]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureSomeTextStructTypeTestSource))]
        public async Task FoldAsync_SourceIsDefaultOrFailure_ExpectResultOfMapFailure(
            Result<RefType, StructType> source)
        {
            var successResult = new SomeRecord
            {
                Text = EmptyString
            };

            var failureResult = new SomeRecord
            {
                Text = SomeString
            };

            var actual = await source.FoldAsync(
                _ => Task.FromResult(successResult),
                _ => Task.FromResult(failureResult));

            Assert.AreEqual(failureResult, actual);
        }
    }
}