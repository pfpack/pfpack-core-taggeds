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
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessPlusFifteenIdRefTypeTestSource))]
        public void FilterValueAsync_PredicateAsyncIsNull_ExpectArgumentNullException(
            Result<RefType, StructType> source)
        {
            var causeFailure = SomeTextStructType;

            var actualException = Assert.ThrowsAsync<ArgumentNullException>(
                async () => _ = await source.FilterValueAsync(null!, _ => ValueTask.FromResult(causeFailure)));

            Assert.AreEqual("predicateAsync", actualException!.ParamName);
        }

        [Test]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureDefaultTestSource))]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureSomeTextStructTypeTestSource))]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessNullTestSource))]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessMinusFifteenIdRefTypeTestSource))]
        public void FilterValueAsync_CauseFactoryAsyncIsNull_ExpectArgumentNullException(
            Result<RefType, StructType> source)
        {
            var actualException = Assert.ThrowsAsync<ArgumentNullException>(
                async () => _ = await source.FilterValueAsync(_ => ValueTask.FromResult(false), null!));

            Assert.AreEqual("causeFactoryAsync", actualException!.ParamName);
        }

        [Test]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessNullTestSource))]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessPlusFifteenIdRefTypeTestSource))]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureDefaultTestSource))]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureSomeTextStructTypeTestSource))]
        public async Task FilterValueAsync_PredicateReturnsTrue_ExpectSourceResult(
            Result<RefType, StructType> source)
        {
            var causeFailure = SomeTextStructType;

            var actual = await source.FilterValueAsync(
                _ => ValueTask.FromResult(true),
                _ => ValueTask.FromResult(causeFailure));

            Assert.AreEqual(source, actual);
        }

        [Test]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessNullTestSource))]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessMinusFifteenIdRefTypeTestSource))]
        public async Task FilterValueAsync_PredicateReturnsFalseAndSourceIsSuccess_ExpectResultOfCauseFailure(
            Result<RefType, StructType> source)
        {
            var causeFailure = new StructType
            {
                Text = "Some failure message."
            };

            var actual = await source.FilterValueAsync(
                _ => ValueTask.FromResult(false),
                _ => ValueTask.FromResult(causeFailure));

            var expected = new Result<RefType, StructType>(causeFailure);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureDefaultTestSource))]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureSomeTextStructTypeTestSource))]
        public async Task FilterValueAsync_PredicateReturnsFalseAndSourceIsDefaultOrFailure_ExpectSourceResult(
            Result<RefType, StructType> source)
        {
            var causeFailure = new StructType
            {
                Text = "Some message."
            };

            var actual = await source.FilterValueAsync(
                _ => ValueTask.FromResult(false),
                _ => ValueTask.FromResult(causeFailure));

            Assert.AreEqual(source, actual);
        }
    }
}