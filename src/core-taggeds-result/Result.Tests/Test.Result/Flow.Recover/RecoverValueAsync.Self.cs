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
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessPlusFifteenIdRefTypeTestSource))]
        public void RecoverValueAsyncSelf_OtherFactoryAsyncIsNull_ExpectArgumentNullException(
            Result<RefType, StructType> source)
        {
            var actualException = Assert.ThrowsAsync<ArgumentNullException>(
                async () => _ = await source.RecoverValueAsync(null!));

            Assert.AreEqual("otherFactoryAsync", actualException!.ParamName);
        }

        [Test]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessNullTestSource))]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessMinusFifteenIdRefTypeTestSource))]
        public async Task RecoverValueAsyncSelf_SourceIsSuccess_ExpectSourceResult(
            Result<RefType, StructType> source)
        {
            var other = new Result<RefType, StructType>(SomeTextStructType);
            var actual = await source.RecoverValueAsync(_ => ValueTask.FromResult(other));

            Assert.AreEqual(source, actual);
        }

        [Test]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureDefaultTestSource))]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureSomeTextStructTypeTestSource))]
        public async Task RecoverValueAsyncSelf_SourceIsDefaultOrFailureAndOtherIsDefault_ExpectDefault(
            Result<RefType, StructType> source)
        {
            var other = new Result<RefType, StructType>();
            var actual = await source.RecoverValueAsync(_ => ValueTask.FromResult(other));

            Assert.AreEqual(other, actual);
        }

        [Test]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureDefaultTestSource))]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureSomeTextStructTypeTestSource))]
        public async Task RecoverValueAsyncSelf_SourceIsDefaultOrFailureAndOtherIsSuccess_ExpectOther(
            Result<RefType, StructType> source)
        {
            Result<RefType, StructType> other = ZeroIdRefType;
            var actual = await source.RecoverValueAsync(_ => ValueTask.FromResult(other));

            Assert.AreEqual(other, actual);
        }

        [Test]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureDefaultTestSource))]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureSomeTextStructTypeTestSource))]
        public async Task RecoverValueAsyncSelf_SourceIsDefaultOrFailureAndOtherIsFailure_ExpectOther(
            Result<RefType, StructType> source)
        {
            var other = Result.Failure(SomeTextStructType).With<RefType>();
            var actual = await source.RecoverValueAsync(_ => ValueTask.FromResult(other));

            Assert.AreEqual(other, actual);
        }
    }
}