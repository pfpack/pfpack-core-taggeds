using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using System;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class TaggedUnionTest
{
    [Test]
    public void Equality_UnionAIsDefaultAndUnionBIsDefault_ExpectTrue()
    {
        var unionA = new TaggedUnion<RefType, StructType>();
        var unionB = default(TaggedUnion<RefType, StructType>);

        var actual = unionA == unionB;
        Assert.True(actual);
    }

    [Test]
    public void Equality_UnionAFirstValueEqualsUnionBFirstValue_ExpectTrue()
    {
        var aValue = new StructType
        {
            Text = SomeString
        };
        var unionA = (TaggedUnion<StructType, RefType?>)aValue;

        var bValue = new StructType
        {
            Text = SomeString
        };
        var unionB = TaggedUnion<StructType, RefType?>.First(bValue);

        var actual = unionA == unionB;
        Assert.True(actual);
    }

    [Test]
    public void Equality_UnionASecondValueEqualsUnionBSecondValue_ExpectTrue()
    {
        var unionA = (TaggedUnion<StructType?, RefType>)ZeroIdRefType;
        var unionB = TaggedUnion<StructType?, RefType>.Second(ZeroIdRefType);

        var actual = unionA == unionB;
        Assert.True(actual);
    }

    [Test]
    public void Equality_UnionAIsDefaultAndUnionBIsFirst_ExpectFalse()
    {
        var unionA = TaggedUnion<StructType, RefType>.First(default);
        var unionB = default(TaggedUnion<StructType, RefType>);

        var actual = unionA == unionB;
        Assert.False(actual);
    }

    [Test]
    public void Equality_UnionAIsDefaultAndUnionBIsSecond_ExpectFalse()
    {
        var unionA = default(TaggedUnion<RefType?, StructType>);
        var unionB = TaggedUnion<RefType?, StructType>.Second(SomeTextStructType);

        var actual = unionA == unionB;
        Assert.False(actual);
    }

    [Test]
    public void Equality_UnionAIsFirstAndUnionBIsDefault_ExpectFalse()
    {
        var unionA = default(TaggedUnion<StructType, RefType>);
        var unionB = TaggedUnion<StructType, RefType>.First(SomeTextStructType);

        var actual = unionA == unionB;
        Assert.False(actual);
    }

    [Test]
    public void Equality_UnionAIsFirstAndUnionBIsSecond_ExpectFalse()
    {
        var unionA = TaggedUnion<StructType, StructType>.First(SomeTextStructType);
        var unionB = TaggedUnion<StructType, StructType>.Second(SomeTextStructType);

        var actual = unionA == unionB;
        Assert.False(actual);
    }

    [Test]
    public void Equality_UnionAIsSecondAndUnionBIsDefault_ExpectFalse()
    {
        var unionA = TaggedUnion<StructType, RefType>.Second(PlusFifteenIdRefType);
        var unionB = default(TaggedUnion<StructType, RefType>);

        var actual = unionA == unionB;
        Assert.False(actual);
    }

    [Test]
    public void Equality_UnionAIsSecondAndUnionBIsFirst_ExpectFalse()
    {
        var unionA = TaggedUnion<RefType, RefType>.Second(ZeroIdRefType);
        var unionB = TaggedUnion<RefType, RefType>.First(ZeroIdRefType);

        var actual = unionA == unionB;
        Assert.False(actual);
    }

    [Test]
    public void Equality_UnionAFirstValueIsNotEqualUnionBFirstValue_ExpectFalse()
    {
        var id = MinusFifteen;

        var aValue = new RefType
        {
            Id = id
        };
        var unionA = TaggedUnion<RefType, StructType?>.First(aValue);

        var bValue = new RefType
        {
            Id = id
        };
        var unionB = TaggedUnion<RefType, StructType?>.First(bValue);

        var actual = unionA == unionB;
        Assert.False(actual);
    }

    [Test]
    public void Equality_UnionASecondValueIsNotEqualUnionBSecondValue_ExpectFalse()
    {
        var aValue = new StructType
        {
            Text = EmptyString
        };
        var unionA = TaggedUnion<RefType, StructType>.Second(aValue);

        var bValue = new StructType
        {
            Text = SomeString
        };
        var unionB = TaggedUnion<RefType, StructType>.Second(bValue);

        var actual = unionA == unionB;
        Assert.False(actual);
    }
}
