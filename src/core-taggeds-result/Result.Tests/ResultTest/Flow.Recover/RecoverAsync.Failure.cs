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
        public void RecoverAsyncFailure_OtherFactoryAsyncIsNull_ExpectArgumentNullException(
            Result<RefType, StructType> source)
        {
            var actualException = Assert.ThrowsAsync<ArgumentNullException>(
                async () => _ = await source.RecoverAsync<SomeError>(null!));

            Assert.AreEqual("otherFactoryAsync", actualException!.ParamName);
        }

        [Test]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessNullTestSource))]
        public async Task RecoverAsyncFailure_SourceIsNullSuccess_ExpectSuccessResultOfSourceValue(
            Result<RefType?, StructType> source)
        {
            var other = new Result<RefType?, int>(PlusFifteen);

            var actual = await source.RecoverAsync(_ => Task.FromResult(other));
            Result<RefType?, int> expected = Result.Success<RefType?>(null);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessMinusFifteenIdRefTypeTestSource))]
        public async Task RecoverAsyncFailure_SourceIsNotNullSuccess_ExpectSuccessResultOfSourceValue(
            Result<RefType, StructType> source)
        {
            var other = new Result<RefType, SomeError>(ZeroIdRefType);

            var actual = await source.RecoverAsync(_ => Task.FromResult(other));
            var expected = new Result<RefType, SomeError>(MinusFifteenIdRefType);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureDefaultTestSource))]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureSomeTextStructTypeTestSource))]
        public async Task RecoverAsyncFailure_SourceIsDefaultOrFailureAndOtherIsDefault_ExpectOther(
            Result<RefType, StructType> source)
        {
            Result<RefType, decimal> other = default(FailureBuilder<decimal>);
            var actual = await source.RecoverAsync(_ => Task.FromResult(other));

            Assert.AreEqual(other, actual);
        }

        [Test]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureDefaultTestSource))]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureSomeTextStructTypeTestSource))]
        public async Task RecoverAsyncFailure_SourceIsDefaultOrFailureAndOtherIsSuccess_ExpectOther(
            Result<RefType, StructType> source)
        {
            var other = Result.Success(ZeroIdRefType).With<SomeError>();
            var actual = await source.RecoverAsync(_ => Task.FromResult(other));

            Assert.AreEqual(other, actual);
        }

        [Test]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureDefaultTestSource))]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureSomeTextStructTypeTestSource))]
        public async Task RecoverAsyncFailure_SourceIsDefaultOrFailureAndOtherIsFailure_ExpectOther(
            Result<RefType, StructType> source)
        {
            var other = new Result<RefType, SomeError>(new SomeError(PlusFifteen));
            var actual = await source.RecoverAsync(_ => Task.FromResult(other));

            Assert.AreEqual(other, actual);
        }
    }
}