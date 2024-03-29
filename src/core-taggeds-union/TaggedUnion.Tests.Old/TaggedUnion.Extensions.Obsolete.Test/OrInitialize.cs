﻿using PrimeFuncPack.UnitTest;
using System;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class TaggedUnionExtensionsTest
{
    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.TaggedUnionTestSource))]
    public void OrInitialize_OtherFactoryIsNull_ExpectArgumentNullException(
        TaggedUnion<RefType, StructType> source)
    {
        var ex = Assert.Throws<ArgumentNullException>(() => _ = TaggedUnionExtensions.OrInitialize(source, null!));
        ClassicAssert.AreEqual("otherFactory", ex!.ParamName);
    }

    [Test]
    public void OrInitialize_SourceIsFirst_ExpectSource()
    {
        var source = TaggedUnion<object, StructType>.First(new object());
        var other = TaggedUnion<object, StructType>.Second(SomeTextStructType);

        var actual = TaggedUnionExtensions.OrInitialize(source, () => other);
        ClassicAssert.AreEqual(source, actual);
    }

    [Test]
    public void OrInitialize_SourceIsSecond_ExpectSource()
    {
        var source = TaggedUnion<object, RefType>.Second(ZeroIdRefType);
        var other = TaggedUnion<object, RefType>.Second(PlusFifteenIdRefType);

        var actual = TaggedUnionExtensions.OrInitialize(source, () => other);
        ClassicAssert.AreEqual(source, actual);
    }

    [Test]
    public void OrInitialize_SourceIsDefault_ExpectOther()
    {
        var source = default(TaggedUnion<object, StructType>);
        var other = TaggedUnion<object, StructType>.First(new object());

        var actual = TaggedUnionExtensions.OrInitialize(source, () => other);
        ClassicAssert.AreEqual(other, actual);
    }
}
