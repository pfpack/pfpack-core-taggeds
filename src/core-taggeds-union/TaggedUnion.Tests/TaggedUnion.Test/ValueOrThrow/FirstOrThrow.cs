using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using System;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class TaggedUnionTest
{
    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.ObjectNullableTestSource))]
    public void FirstOrThrow_SourceIsFirst_ExpectSourceValue(
        object? sourceValue)
    {
        var source = TaggedUnion<object?, StructType>.First(sourceValue);

        var actual = source.FirstOrThrow();
        Assert.AreEqual(sourceValue, actual);
    }

    [Test]
    public void FirstOrThrow_SourceIsSecond_ExpectInvalidOperationException()
    {
        var source = TaggedUnion<StructType, RefType>.Second(PlusFifteenIdRefType);

        var ex = Assert.Throws<InvalidOperationException>(() => _ = source.FirstOrThrow());
        AssertContainsFirst(First, ex!.Message);
    }

    [Test]
    public void FirstOrThrow_SourceIsDefault_ExpectInvalidOperationException()
    {
        var source = default(TaggedUnion<int, string>);

        var ex = Assert.Throws<InvalidOperationException>(() => _ = source.FirstOrThrow());
        AssertContainsFirst(First, ex!.Message);
    }
}
