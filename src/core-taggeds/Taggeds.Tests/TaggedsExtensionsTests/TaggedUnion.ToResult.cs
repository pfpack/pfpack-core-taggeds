using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using System;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class TaggedUnionResultExtensions
{
    [Test]
    public void TaggedUnion_ToResult_SourceUnionIsDefault_ExpectDefaultResult()
    {
        var sourceUnion = default(TaggedUnion<SomeRecord, StructType>);

        var actual = sourceUnion.ToResult();
        var expected = default(Result<SomeRecord, StructType>);

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void TaggedUnion_ToResult_SourceUnionIsSecond_ExpectFailureResult()
    {
        var sourceValue = new SomeError(MinusFifteen);
        var sourceUnion = TaggedUnion<RefType?, SomeError>.Second(sourceValue);

        var actual = sourceUnion.ToResult();
        var expected = Result<RefType?, SomeError>.Failure(sourceValue);

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void TaggedUnion_ToResult_SourceUnionIsFirstAndSourceValueIsNull_ExpectSuccessResultOfNullValue()
    {
        var sourceUnion = TaggedUnion<RefType?, StructType>.First(null);

        var actual = sourceUnion.ToResult();
        var expected = Result<RefType?, StructType>.Success(null);

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void TaggedUnion_ToResult_SourceUnionIsFirstAndSourceValueIsNotNull_ExpectSuccessResultOfSourceValue()
    {
        var sourceValue = new SomeRecord
        {
            Text = SomeString
        };
        var sourceUnion = TaggedUnion<SomeRecord, SomeError>.First(sourceValue);

        var actual = sourceUnion.ToResult();
        var expected = Result<SomeRecord, SomeError>.Success(sourceValue);

        Assert.That(actual, Is.EqualTo(expected));
    }
}
