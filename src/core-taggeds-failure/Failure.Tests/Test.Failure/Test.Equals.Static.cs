using System;
using Xunit;

namespace PrimeFuncPack.Core.Tests;

partial class FailureTest
{
    [Theory]
    [MemberData(nameof(FailureTestSource.EqualPairTestData), MemberType = typeof(FailureTestSource))]
    public static void EqualsStatic_LeftIsEqualToRight_ExpectTrue(
        Failure<SomeFailureCode> left, Failure<SomeFailureCode> right)
    {
        var actual = Failure<SomeFailureCode>.Equals(left, right);
        Assert.True(actual);
    }

    [Theory]
    [MemberData(nameof(FailureTestSource.UnequalPairTestData), MemberType = typeof(FailureTestSource))]
    public static void EqualsStatic_LeftIsNotEqualToRight_ExpectFalse(
        Failure<SomeFailureCode> left, Failure<SomeFailureCode> right)
    {
        var actual = Failure<SomeFailureCode>.Equals(left, right);
        Assert.False(actual);
    }
}
