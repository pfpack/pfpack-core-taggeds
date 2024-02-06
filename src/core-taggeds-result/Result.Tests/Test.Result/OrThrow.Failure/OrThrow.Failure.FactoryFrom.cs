using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using System;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class ResultTest
{
    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureDefaultTestSource))]
    public void FailureOrThrowWithExceptionFactoryFromSuccess_ExceptionFactoryIsNull_ExpectDefaultFailureValue(
        Result<RefType, StructType> source)
    {
        var exceptionFactory = (Func<RefType, Exception>)null!;
        var actualException = Assert.Throws<ArgumentNullException>(Test);

        Assert.That(actualException!.ParamName, Is.EqualTo("exceptionFactory"));

        void Test()
            =>
            _ = source.FailureOrThrow(exceptionFactory);
    }

    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureDefaultTestSource))]
    public void FailureOrThrowWithExceptionFactoryFromSuccess_SourceIsDefault_ExpectDefaultFailureValue(
        Result<RefType, StructType> source)
    {
        var actual = source.FailureOrThrow(CreateException);
        var expected = default(StructType);

        Assert.That(actual, Is.EqualTo(expected));

        static Exception CreateException(RefType success)
            =>
            new SomeException<RefType>(success);
    }

    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureSomeTextStructTypeTestSource))]
    public void FailureOrThrowWithExceptionFactoryFromSuccess_SourceIsFailure_ExpectFailureValue(
        Result<RefType, StructType> source)
    {
        var actual = source.FailureOrThrow(CreateException);
        var expected = SomeTextStructType;

        Assert.That(actual, Is.EqualTo(expected));

        static Exception CreateException(RefType success)
            =>
            new SomeException<RefType>(success);
    }

    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessPlusFifteenIdRefTypeTestSource))]
    public void FailureOrThrowWithExceptionFactoryFromSuccess_SourceIsSuccess_ExpectExceptionFromFactory(
        Result<RefType, StructType> source)
    {
        var actualException = Assert.Throws<SomeException<RefType>>(Test);

        Assert.That(actualException!.Value, Is.EqualTo(PlusFifteenIdRefType));

        void Test()
            =>
            _ = source.FailureOrThrow(CreateException);

        static Exception CreateException(RefType success)
            =>
            new SomeException<RefType>(success);
    }
}