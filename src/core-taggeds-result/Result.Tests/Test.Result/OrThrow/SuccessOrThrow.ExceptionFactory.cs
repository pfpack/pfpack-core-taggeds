using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using System;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests
{
    partial class ResultTest
    {
        [Test]        
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessNullTestSource))]
        public void SuccessOrThrowWithExceptionFactory_SourceIsSuccessAndValueIsNull_ExpectNull(
            Result<RefType, StructType> source)
        {
            var actual = source.SuccessOrThrow(() => new SomeException());
            Assert.IsNull(actual);
        }

        [Test]    
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessMinusFifteenIdRefTypeTestSource))]
        public void SuccessOrThrowWithExceptionFactory_SourceIsSuccessAndValueIsNotNull_ExpectSuccessValue(
            Result<RefType, StructType> source)
        {
            var actual = source.SuccessOrThrow(() => new SomeException());
            var expected = MinusFifteenIdRefType;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureDefaultTestSource))]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureSomeTextStructTypeTestSource))]
        public void SuccessOrThrowWithExceptionFactory_SourceIsDefaultOrFailure_ExpectExceptionFromFactory(
            Result<RefType, StructType> source)
        {
            var exceptionFromFactory = new SomeException();

            var actualException = Assert.Throws<SomeException>(
                () => _ = source.SuccessOrThrow(() => exceptionFromFactory));
                
            Assert.AreEqual(exceptionFromFactory, actualException);
        }
    }
}