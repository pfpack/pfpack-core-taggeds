using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using System;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class ResultTest
{
    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessMinusFifteenIdRefTypeTestSource))]
    public void SuccessOrThrowWithExceptionFactoryFromFailure_ExceptionFactoryIsNull_ExpectArgumentNullException(
        Result<RefType, StructType> source)
    {
        var exceptionFactory = (Func<StructType, Exception>)null!;
        var actualException = Assert.Throws<ArgumentNullException>(Test);
        
        Assert.AreEqual("exceptionFactory", actualException?.ParamName);

        void Test()
            =>
            _ = source.SuccessOrThrow(exceptionFactory);
    }

    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessNullTestSource))]
    public void SuccessOrThrowWithExceptionFactoryFromFailure_SourceIsSuccessAndValueIsNull_ExpectNull(
        Result<RefType, StructType> source)
    {
        var actual = source.SuccessOrThrow(CreateException);
        Assert.IsNull(actual);

        static Exception CreateException(StructType failure)
            =>
            new SomeException<StructType>(failure);
    }

    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessPlusFifteenIdRefTypeTestSource))]
    public void SuccessOrThrowWithExceptionFactoryFromFailure_SourceIsSuccessAndValueIsNotNull_ExpectSuccessValue(
        Result<RefType, StructType> source)
    {
        var actual = source.SuccessOrThrow(CreateException);
        var expected = PlusFifteenIdRefType;

        Assert.AreEqual(expected, actual);

        static Exception CreateException(StructType failure)
            =>
            new SomeException<StructType>(failure);
    }

    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureSomeTextStructTypeTestSource))]
    public void SuccessOrThrowWithExceptionFactoryFromFailure_SourceIsDefaultOrFailure_ExpectExceptionFromFactory(
        Result<RefType, StructType> source)
    {
        var actualException = Assert.Throws< SomeException<StructType>>(Test);

        Assert.AreEqual(SomeTextStructType, actualException?.Value);

        void Test()
            =>
            _ = source.SuccessOrThrow(CreateException);

        static SomeException<StructType> CreateException(StructType failure)
            =>
            new(failure);
    }
}
