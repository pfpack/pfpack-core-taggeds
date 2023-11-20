using System;
using Xunit;

namespace PrimeFuncPack.Core.Tests;

partial class FailureTest
{
    [Theory]
    [MemberData(nameof(FailureTestSource.EqualPairTestData), MemberType = typeof(FailureTestSource))]
    public static void EqualsObject_SourceIsEqualToObjectAndTypesAreSame_ExpectTrue(
        Failure<SomeFailureCode> source, object? obj)
    {
        var actual = source.Equals(obj);
        Assert.True(actual);
    }

    [Fact]
    public static void EqualsObject_ObjIsNull_ExpectFalse()
    {
        var source = new Failure<SomeFailureCode>(SomeFailureCode.Unknown, null);

        var actual = source.Equals(null);
        Assert.False(actual);
    }

    [Fact]
    public static void EqualsObject_SourceTypeIsNotEqualToObjectType_ExpectFalse()
    {
        var source = default(Failure<SomeFailureCode>);
        object? obj = default(Failure<int>);

        var actual = source.Equals(obj);
        Assert.False(actual);
    }

    [Theory]
    [MemberData(nameof(FailureTestSource.UnequalPairTestData), MemberType = typeof(FailureTestSource))]
    public static void EqualsObject_SourceIsNotEqualToObjectAndTypesAreSame_ExpectFalse(
        Failure<SomeFailureCode> source, Failure<SomeFailureCode> obj)
    {
        var actual = source.Equals(obj);
        Assert.False(actual);
    }
}
