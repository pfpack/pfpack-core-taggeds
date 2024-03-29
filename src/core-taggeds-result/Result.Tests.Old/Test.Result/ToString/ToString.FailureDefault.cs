using PrimeFuncPack.UnitTest;
using System;
using System.Globalization;

namespace PrimeFuncPack.Core.Tests;

partial class ResultTest
{
    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureDefaultTestSource))]
    public void ToString_SourceIsFailureDefault(
        Result<RefType, StructType> source)
    {
        var actual = source.ToString();

        var expected = string.Format(
            CultureInfo.InvariantCulture,
            "Result<{0}, {1}>:Failure:{2}",
            typeof(RefType).Name,
            typeof(StructType).Name,
            default(StructType));

        Assert.That(actual, Is.EqualTo(expected));
    }
}
