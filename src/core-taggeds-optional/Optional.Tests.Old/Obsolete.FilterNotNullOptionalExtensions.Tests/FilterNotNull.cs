using PrimeFuncPack.UnitTest;
using System;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class ObsoleteFilterNotNullOptionalExtensionsTests
{
    [Test]
    public void FilterNotNull_Class_SourceValueIsNotNull_ExpectSource()
    {
        var source = Optional<RefType?>.Present(PlusFifteenIdRefType);

        var actual = FilterNotNullOptionalExtensions.FilterNotNull(source);
        Assert.That(actual, Is.EqualTo(source));
    }

    [Test]
    public void FilterNotNull_Struct_SourceValueIsNotNull_ExpectSource()
    {
        var source = Optional<int?>.Present(PlusFifteen);

        var actual = FilterNotNullOptionalExtensions.FilterNotNull(source);
        Assert.That(actual.IsPresent, Is.True);
        Assert.That(actual.OrThrow(), Is.EqualTo(source.OrThrow()!.Value));
    }

    [Test]
    public void FilterNotNull_SourceValueIsNull_ExpectAbsent()
    {
        var source = Optional<RefType?>.Present(null);

        var actual = FilterNotNullOptionalExtensions.FilterNotNull(source);
        var expected = Optional<RefType?>.Absent;

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void FilterNotNull_SourceValueIsNotNullRefType_ExpectNotNullableRefTypePresent()
    {
        var sourceValue = MinusFifteenIdRefType;
        var source = Optional<RefType?>.Present(sourceValue);

        var actual = FilterNotNullOptionalExtensions.FilterNotNull(source);
        var expected = Optional<RefType>.Present(sourceValue);

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void FilterNotNull_SourceValueIsNullRefType_ExpectNotNullableRefTypeAbsent()
    {
        var source = Optional<RefType?>.Present(null);

        var actual = FilterNotNullOptionalExtensions.FilterNotNull(source);
        var expected = Optional<RefType>.Absent;

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void FilterNotNull_SourceValueIsNotNullStructType_ExpectNotNullableStructTypePresent()
    {
        var sourceValue = SomeTextStructType;
        var source = Optional<StructType?>.Present(sourceValue);

        var actual = FilterNotNullOptionalExtensions.FilterNotNull(source);
        var expected = Optional<StructType>.Present(sourceValue);

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void FilterNotNull_SourceValueIsNullStructType_ExpectNotNullableStructTypeAbsent()
    {
        var source = Optional<StructType?>.Present(null);

        var actual = FilterNotNullOptionalExtensions.FilterNotNull(source);
        var expected = Optional<StructType>.Absent;

        Assert.That(actual, Is.EqualTo(expected));
    }
}
