using System;
using PrimeFuncPack.UnitTest;

namespace PrimeFuncPack.Core.Tests;

partial class FailureTest
{
    [Theory]
    [MemberData(nameof(FailureTestSource.EqualPairTestData), MemberType = typeof(FailureTestSource))]
    public static void EqualsStatic_LeftIsEqualToRight_ExpectTrue(
        Failure<EnumType> left, Failure<EnumType> right)
    {
        var actual = Failure<EnumType>.Equals(left, right);
        Assert.True(actual);
    }

    [Theory]
    [MemberData(nameof(FailureTestSource.UnequalPairTestData), MemberType = typeof(FailureTestSource))]
    public static void EqualsStatic_LeftIsNotEqualToRight_ExpectFalse(
        Failure<EnumType> left, Failure<EnumType> right)
    {
        var actual = Failure<EnumType>.Equals(left, right);
        Assert.False(actual);
    }
}
