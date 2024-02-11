using System;
using PrimeFuncPack.UnitTest;

namespace PrimeFuncPack.Core.Tests;

partial class FailureTest
{
    [Theory]
    [MemberData(nameof(FailureTestSource.EqualPairTestData), MemberType = typeof(FailureTestSource))]
    public static void Equality_LeftIsEqualToRight_ExpectTrue(
        Failure<EnumType> left, Failure<EnumType> right)
    {
        var actual = left == right;
        Assert.True(actual);
    }

    [Theory]
    [MemberData(nameof(FailureTestSource.UnequalPairTestData), MemberType = typeof(FailureTestSource))]
    public static void Equality_LeftIsNotEqualToRight_ExpectTrue(
        Failure<EnumType> left, Failure<EnumType> right)
    {
        var actual = left == right;
        Assert.False(actual);
    }
}
