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
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessMinusFifteenIdRefTypeTestSource))]
        public void Map_MapSuccessIsNull_ExpectArgumentNullException(
            Result<RefType, StructType> source)
        {            
            var actualException = Assert.Throws<ArgumentNullException>(
                () => _ = source.Map<int, decimal>(null!, _ => decimal.MaxValue));

            Assert.AreEqual("mapSuccess", actualException!.ParamName);
        }

        [Test]        
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureDefaultTestSource))]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureSomeTextStructTypeTestSource))]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessNullTestSource))]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessMinusFifteenIdRefTypeTestSource))]
        public void Map_MapFailureIsNull_ExpectArgumentNullException(
            Result<RefType, StructType> source)
        {
            var actualException = Assert.Throws<ArgumentNullException>(
                () => _ = source.Map<object, SomeError>(_ => new object(), null!));

            Assert.AreEqual("mapFailure", actualException!.ParamName);
        }

        [Test]        
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessNullTestSource))]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessPlusFifteenIdRefTypeTestSource))]
        public void Map_SourceIsSuccess_ExpectSuccessResultOfMapSuccess(
            Result<RefType, StructType> source)
        {
            var successResult = new SomeRecord();
            var failureResult = new SomeError(MinusFifteen);

            var actual = source.Map(
                _ => successResult,
                _ => failureResult);
            
            var exected = new Result<SomeRecord, SomeError>(successResult);
            Assert.AreEqual(exected, actual);
        }

        [Test]        
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureDefaultTestSource))]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureSomeTextStructTypeTestSource))]
        public void Map_SourceIsDefaultOrFailure_FailureExpectResultOfMapFailure(
            Result<RefType, StructType> source)
        {
            var successResult = new SomeRecord
            {
                Text = SomeString
            };

            var failureResult = default(SomeError);

            var actual = source.Map(
                _ => successResult,
                _ => failureResult);

            var exected = new Result<SomeRecord, SomeError>(failureResult);
            Assert.AreEqual(exected, actual);
        }
    }
}