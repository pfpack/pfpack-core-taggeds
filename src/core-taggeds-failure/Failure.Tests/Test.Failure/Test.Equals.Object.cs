using System;
using PrimeFuncPack.UnitTest;
using Xunit;

namespace PrimeFuncPack.Core.Tests;

partial class FailureTest
{
    [Theory]
    [MemberData(nameof(FailureTestSource.EqualPairTestData), MemberType = typeof(FailureTestSource))]
    public static void EqualsObject_SourceIsEqualToObjectAndTypesAreSame_ExpectTrue(
        Failure<EnumType> source, object? obj)
    {
        var actual = source.Equals(obj);
        Assert.True(actual);
    }

    [Fact]
    public static void EqualsObject_ObjIsNull_ExpectFalse()
    {
        var source = new Failure<EnumType>(EnumType.Zero, null);

        var actual = source.Equals(null);
        Assert.False(actual);
    }

    [Fact]
    public static void EqualsObject_SourceTypeIsNotEqualToObjectType_ExpectFalse()
    {
        var source = default(Failure<EnumType>);
        object? obj = default(Failure<int>);

        var actual = source.Equals(obj);
        Assert.False(actual);
    }

    [Theory]
    [MemberData(nameof(FailureTestSource.UnequalPairTestData), MemberType = typeof(FailureTestSource))]
    public static void EqualsObject_SourceIsNotEqualToObjectAndTypesAreSame_ExpectFalse(
        Failure<EnumType> source, Failure<EnumType> obj)
    {
        var actual = source.Equals(obj);
        Assert.False(actual);
    }
}
