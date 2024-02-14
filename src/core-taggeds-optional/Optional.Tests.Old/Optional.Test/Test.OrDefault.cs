using PrimeFuncPack.UnitTest;
using System;

namespace PrimeFuncPack.Core.Tests;

partial class OptionalTest
{
    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.ObjectNullableTestSource))]
    public void OrDefault_SourceIsPresent_ExpectSourceValue(
        object sourceValue)
    {
        var source = Optional<object>.Present(sourceValue);

        var actual = source.OrDefault();
        Assert.That(actual, Is.SameAs(sourceValue));
    }

    [Test]
    public void OrDefault_SourceIsStructTypeAbsent_ExpectDefaultStructValue()
    {
        var source = Optional<StructType>.Absent;

        var actual = source.OrDefault();
        Assert.That(actual, Is.EqualTo(default(StructType)));
    }

    [Test]
    public void OrDefault_SourceIsRefTypeAbsent_ExpectNull()
    {
        var source = Optional<RefType>.Absent;

        var actual = source.OrDefault();
        Assert.That(actual, Is.Null);
    }
}
