using PrimeFuncPack.UnitTest;
using System;

namespace PrimeFuncPack.Core.Tests;

partial class TaggedsExtensionsTests
{
    [Obsolete]
    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.ObjectNullableTestSource))]
    public void TaggedUnion_ToOptional_UnionIsFirst_ExpectPresent(
        object? sourceValue)
    {
        var union = TaggedUnion<object?, Unit>.First(sourceValue);
        var actual = union.ToOptional();

        var expected = Optional.Present(sourceValue);
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Obsolete]
    [Test]
    public void TaggedUnion_ToOptional_UnionIsDefault_ExpectAbsent()
    {
        var union = default(TaggedUnion<StructType, Unit>);
        var actual = union.ToOptional();

        var expected = Optional.Absent<StructType>();
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Obsolete]
    [Test]
    public void TaggedUnion_ToOptional_UnionIsSecond_ExpectAbsent()
    {
        var union = TaggedUnion<RefType, Unit>.Second(Unit.Value);
        var actual = union.ToOptional();

        var expected = Optional.Absent<RefType>();
        Assert.That(actual, Is.EqualTo(expected));
    }
}
