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
        public void FilterAsyncWithMapFailure_PredicateIsNull_ExpectArgumentNullException(
            Result<RefType, StructType> source)
        {
            var cause = int.MaxValue;
            var mapped = Zero;

            var actualException = Assert.ThrowsAsync<ArgumentNullException>(
                async () => _ = await source.FilterAsync(null!, _ => Task.FromResult(cause), _ => Task.FromResult(mapped)));

            Assert.AreEqual("predicateAsync", actualException!.ParamName);
        }

        [Test]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureDefaultTestSource))]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureSomeTextStructTypeTestSource))]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessNullTestSource))]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessPlusFifteenIdRefTypeTestSource))]
        public void FilterAsyncWithMapFailure_CauseFactoryIsNull_ExpectArgumentNullException(
            Result<RefType, StructType> source)
        {
            var mapped = new SomeError(MinusFifteen);

            var actualException = Assert.ThrowsAsync<ArgumentNullException>(
                async () => _ = await source.FilterAsync(_ => Task.FromResult(true), null!, _ => Task.FromResult(mapped)));

            Assert.AreEqual("causeFactoryAsync", actualException!.ParamName);
        }

        [Test]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureDefaultTestSource))]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureSomeTextStructTypeTestSource))]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessNullTestSource))]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessMinusFifteenIdRefTypeTestSource))]
        public void FilterAsyncWithMapFailure_MapFailureIsNull_ExpectArgumentNullException(
            Result<RefType, StructType> source)
        {
            var cause = default(SomeError);

            var actualException = Assert.ThrowsAsync<ArgumentNullException>(
                async () => _ = await source.FilterAsync(_ => Task.FromResult(false), _ => Task.FromResult(cause), null!));

            Assert.AreEqual("mapFailureAsync", actualException!.ParamName);
        }

        [Test]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessNullTestSource))]
        public async Task FilterAsyncWithMapFailure_PredicateReturnsTrueAndSourceIsNullSuccess_ExpectSuccessResultOfNull(
            Result<RefType?, StructType> source)
        {
            var cause = new SomeError(PlusFifteen);
            var mapped = new SomeError(int.MaxValue);

            var actual = await source.FilterAsync(
                _ => Task.FromResult(true),
                _ => Task.FromResult(cause),
                _ => Task.FromResult(mapped));

            var expected = new Result<RefType?, SomeError>(null);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessPlusFifteenIdRefTypeTestSource))]
        public async Task FilterAsyncWithMapFailure_PredicateReturnsTrueAndSourceIsNotNullSuccess_ExpectSuccessResultOfSorceValue(
            Result<RefType, StructType> source)
        {
            var cause = new SomeError(int.MaxValue);
            var mapped = new SomeError(int.MinValue);

            var actual = await source.FilterAsync(
                _ => Task.FromResult(true),
                _ => Task.FromResult(cause),
                _ => Task.FromResult(mapped));

            var expected = new Result<RefType, SomeError>(PlusFifteenIdRefType);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureDefaultTestSource))]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureSomeTextStructTypeTestSource))]
        public async Task FilterAsyncWithMapFailure_PredicateReturnsTrueAndSourceIsFailure_ExpectFailureResultOfMappedValue(
            Result<RefType, StructType> source)
        {
            var cause = new SomeError(MinusFifteen);
            var mapped = new SomeError(PlusFifteen);

            var actual = await source.FilterAsync(
                _ => Task.FromResult(true),
                _ => Task.FromResult(cause),
                _ => Task.FromResult(mapped));

            var expected = new Result<RefType, SomeError>(mapped);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessNullTestSource))]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessPlusFifteenIdRefTypeTestSource))]
        public async Task FilterAsyncWithMapFailure_PredicateReturnsFalseAndSourceIsSuccess_ExpectResultOfCauseFailure(
            Result<RefType, StructType> source)
        {
            var cause = decimal.One;
            var mapped = decimal.MinValue;

            var actual = await source.FilterAsync(
                _ => Task.FromResult(false),
                _ => Task.FromResult(cause),
                _ => Task.FromResult(mapped));

            var expected = new Result<RefType, decimal>(cause);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureDefaultTestSource))]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureSomeTextStructTypeTestSource))]
        public async Task FilterAsyncWithMapFailure_PredicateReturnsFalseAndSourceIsDefaultOrFailure_ExpectResultOfMappedFailure(
            Result<RefType, StructType> source)
        {            
            var cause = new SomeError(int.MaxValue);
            var mapped = new SomeError(MinusFifteen);

            var actual = await source.FilterAsync(
                _ => Task.FromResult(false),
                _ => Task.FromResult(cause),
                _ => Task.FromResult(mapped));
            
            var expected = new Result<RefType, SomeError>(mapped);
            Assert.AreEqual(expected, actual);
        }
    }
}