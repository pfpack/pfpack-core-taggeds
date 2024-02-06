using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using System;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class ResultTest
{
    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureDefaultTestSource))]
    public void FailureOrThrowWithExceptionFactory_ExceptionFactoryIsNull_ExpectArgumentNullException(
        Result<RefType, StructType> source)
    {
        var exceptionFactory = (Func<Exception>)null!;
        var actualException = Assert.Throws<ArgumentNullException>(Test);

        Assert.That(actualException!.ParamName, Is.EqualTo("exceptionFactory"));

        void Test()
            =>
            _ = source.FailureOrThrow(exceptionFactory);
    }

    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureDefaultTestSource))]
    public void FailureOrThrowWithExceptionFactory_SourceIsDefault_ExpectDefaultFailureValue(
        Result<RefType, StructType> source)
    {
        var actual = source.FailureOrThrow(CreateException);
        var expected = default(StructType);

        Assert.That(actual, Is.EqualTo(expected));

        static Exception CreateException()
            =>
            new SomeException();
    }

    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureSomeTextStructTypeTestSource))]
    public void FailureOrThrowWithExceptionFactory_SourceIsFailure_ExpectFailureValue(
        Result<RefType, StructType> source)
    {
        var actual = source.FailureOrThrow(CreateException);
        var expected = SomeTextStructType;

        Assert.That(actual, Is.EqualTo(expected));

        static Exception CreateException()
            =>
            new SomeException();
    }

    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessNullTestSource))]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessPlusFifteenIdRefTypeTestSource))]
    public void FailureOrThrowWithExceptionFactory_SourceIsSuccess_ExpectExceptionFromFactory(
        Result<RefType, StructType> source)
    {
        var exceptionFromFactory = new SomeException();
        var actualException = Assert.Throws<SomeException>(Test);

        Assert.That(actualException, Is.SameAs(exceptionFromFactory));

        void Test()
            =>
            _ = source.FailureOrThrow(() => exceptionFromFactory);
    }
}
