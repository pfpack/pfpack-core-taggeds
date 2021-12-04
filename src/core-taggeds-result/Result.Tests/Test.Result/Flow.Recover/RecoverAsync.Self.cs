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
        public void RecoverAsyncSelf_OtherFactoryAsyncIsNull_ExpectArgumentNullException(
            Result<RefType, StructType> source)
        {
            var actualException = Assert.ThrowsAsync<ArgumentNullException>(
                async () => _ = await source.RecoverAsync(null!));

            Assert.AreEqual("otherFactoryAsync", actualException!.ParamName);
        }

        [Test]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessNullTestSource))]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessMinusFifteenIdRefTypeTestSource))]
        public async Task RecoverAsyncSelf_SourceIsSuccess_ExpectSourceResult(
            Result<RefType, StructType> source)
        {
            Result<RefType, StructType> other = null!;
            var actual = await source.RecoverAsync(_ => Task.FromResult(other));

            Assert.AreEqual(source, actual);
        }

        [Test]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureDefaultTestSource))]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureSomeTextStructTypeTestSource))]
        public async Task RecoverAsyncSelf_SourceIsDefaultOrFailureAndOtherIsDefault_ExpectDefault(
            Result<RefType, StructType> source)
        {
            var other = new Result<RefType, StructType>();
            var actual = await source.RecoverAsync(_ => Task.FromResult(other));

            Assert.AreEqual(other, actual);
        }

        [Test]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureDefaultTestSource))]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureSomeTextStructTypeTestSource))]
        public async Task RecoverAsyncSelf_SourceIsDefaultOrFailureAndOtherIsSuccess_ExpectOther(
            Result<RefType, StructType> source)
        {
            Result<RefType, StructType> other = Result.Success(PlusFifteenIdRefType);
            var actual = await source.RecoverAsync(_ => Task.FromResult(other));

            Assert.AreEqual(other, actual);
        }

        [Test]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureDefaultTestSource))]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureSomeTextStructTypeTestSource))]
        public async Task RecoverAsyncSelf_SourceIsDefaultOrFailureAndOtherIsFailure_ExpectOther(
            Result<RefType, StructType> source)
        {
            var other = new Result<RefType, StructType>(SomeTextStructType);
            var actual = await source.RecoverAsync(_ => Task.FromResult(other));

            Assert.AreEqual(other, actual);
        }
    }
}