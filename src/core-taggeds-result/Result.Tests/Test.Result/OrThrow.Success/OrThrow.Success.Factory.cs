using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using System;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class ResultTest
{
    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessMinusFifteenIdRefTypeTestSource))]
    public void SuccessOrThrowWithExceptionFactory_ExceptionFactoryIsNull_ExpectArgumentNullException(
        Result<RefType, StructType> source)
    {
        var exceptionFactory = (Func<Exception>)null!;
        var actualException = Assert.Throws<ArgumentNullException>(Test);
        
        Assert.That(actualException!.ParamName, Is.EqualTo("exceptionFactory"));

        void Test()
            =>
            _ = source.SuccessOrThrow(exceptionFactory);
    }

    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessNullTestSource))]
    public void SuccessOrThrowWithExceptionFactory_SourceIsSuccessAndValueIsNull_ExpectNull(
        Result<RefType, StructType> source)
    {
        var actual = source.SuccessOrThrow(CreateException);
        Assert.That(actual, Is.Null);

        static Exception CreateException()
            =>
            new SomeException();
    }

    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessMinusFifteenIdRefTypeTestSource))]
    public void SuccessOrThrowWithExceptionFactory_SourceIsSuccessAndValueIsNotNull_ExpectSuccessValue(
        Result<RefType, StructType> source)
    {
        var actual = source.SuccessOrThrow(CreateException);
        var expected = MinusFifteenIdRefType;

        Assert.That(actual, Is.SameAs(expected));

        static Exception CreateException()
            =>
            new SomeException();
    }

    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureDefaultTestSource))]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureSomeTextStructTypeTestSource))]
    public void SuccessOrThrowWithExceptionFactory_SourceIsDefaultOrFailure_ExpectExceptionFromFactory(
        Result<RefType, StructType> source)
    {
        var exceptionFromFactory = new SomeException();
        var actualException = Assert.Throws<SomeException>(Test);

        Assert.That(actualException, Is.SameAs(exceptionFromFactory));

        void Test()
            =>
            _ = source.SuccessOrThrow(CreateException);

        Exception CreateException()
            =>
            exceptionFromFactory;
    }
}
