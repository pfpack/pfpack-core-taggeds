﻿using PrimeFuncPack.UnitTest;
using System;
using System.Threading.Tasks;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class TaggedUnionExtensionsTest
{
    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.TaggedUnionTestSource))]
    public void OrInitializeAsync_OtherFactoryAsyncIsNull_ExpectArgumentNullException(
        TaggedUnion<RefType, StructType> source)
    {
        var ex = Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await TaggedUnionExtensions.OrInitializeAsync(source, null!));
        ClassicAssert.AreEqual("otherFactoryAsync", ex!.ParamName);
    }

    [Test]
    public async Task OrInitializeAsync_SourceIsFirst_ExpectSource()
    {
        var source = TaggedUnion<RefType?, StructType>.First(null);
        var other = TaggedUnion<RefType?, StructType>.First(ZeroIdRefType);

        var actual = await TaggedUnionExtensions.OrInitializeAsync(source, () => Task.FromResult(other));
        ClassicAssert.AreEqual(source, actual);
    }

    [Test]
    public async Task OrInitializeAsync_SourceIsSecond_ExpectSource()
    {
        var source = TaggedUnion<object, StructType>.Second(SomeTextStructType);
        var other = default(TaggedUnion<object, StructType>);

        var actual = await TaggedUnionExtensions.OrInitializeAsync(source, () => Task.FromResult(other));
        ClassicAssert.AreEqual(source, actual);
    }

    [Test]
    public async Task OrInitializeAsync_SourceIsDefault_ExpectOther()
    {
        var source = default(TaggedUnion<int, RefType>);
        var other = TaggedUnion<int, RefType>.Second(new RefType());

        var actual = await TaggedUnionExtensions.OrInitializeAsync(source, () => Task.FromResult(other));
        ClassicAssert.AreEqual(other, actual);
    }
}
