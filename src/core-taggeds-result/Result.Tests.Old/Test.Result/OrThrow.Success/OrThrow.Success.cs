using PrimeFuncPack.UnitTest;
using System;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class ResultTest
{
    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessNullTestSource))]
    public void SuccessOrThrow_SourceIsSuccessAndValueIsNull_ExpectNull(
        Result<RefType?, StructType> source)
    {
        var actual = source.SuccessOrThrow();
        Assert.That(actual, Is.Null);
    }

    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessPlusFifteenIdRefTypeTestSource))]
    public void SuccessOrThrow_SourceIsSuccessAndValueIsNotNull_ExpectSuccessValue(
        Result<RefType, StructType> source)
    {
        var actual = source.SuccessOrThrow();
        var expected = PlusFifteenIdRefType;

        Assert.That(actual, Is.SameAs(expected));
    }

    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureDefaultTestSource))]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureSomeTextStructTypeTestSource))]
    public void SuccessOrThrow_SourceIsDefaultOrFailure_ExpectInvalidOperationException(
        Result<RefType, StructType> source)
    {
        var actualEx = Assert.Throws<InvalidOperationException>(Test);

        Assert.That(actualEx!.Message.Contains("Success", StringComparison.Ordinal));

        void Test()
            =>
            _ = source.SuccessOrThrow();
    }
}
