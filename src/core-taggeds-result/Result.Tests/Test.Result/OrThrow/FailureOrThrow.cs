using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using System;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class ResultTest
{
    [Test]        
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureDefaultTestSource))]
    public void FailureOrThrow_SourceIsDefault_ExpectDefaultFailureValue(
        Result<RefType, StructType> source)
    {
        var actual = source.FailureOrThrow();
        var expected = default(StructType);

        Assert.AreEqual(expected, actual);
    }

    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureSomeTextStructTypeTestSource))]
    public void FailureOrThrow_SourceIsFailure_ExpectFailureValue(
        Result<RefType, StructType> source)
    {
        var actual = source.FailureOrThrow();
        var expected = SomeTextStructType;

        Assert.AreEqual(expected, actual);
    }

    [Test]        
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessNullTestSource))]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessPlusFifteenIdRefTypeTestSource))]
    public void FailureOrThrow_SourceIsSuccess_ExpectInvalidOperationException(
        Result<RefType, StructType> source)
    {
        var actualEx = Assert.Throws<InvalidOperationException>(
            () => _ = source.FailureOrThrow());
                
        Assert.True(actualEx!.Message.Contains("Failure", StringComparison.InvariantCultureIgnoreCase));
    }
}
