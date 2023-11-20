using System;
using Xunit;

namespace PrimeFuncPack.Core.Tests;

partial class FailureTest
{
    [Theory]
    [MemberData(nameof(FailureTestSource.EqualPairTestData), MemberType = typeof(FailureTestSource))]
    public static void Inequality_LeftIsEqualToRight_ExpectFalse(
        Failure<SomeFailureCode> left, Failure<SomeFailureCode> right)
    {
        var actual = left != right;
        Assert.False(actual);
    }

    [Theory]
    [MemberData(nameof(FailureTestSource.UnequalPairTestData), MemberType = typeof(FailureTestSource))]
    public static void Inequality_LeftIsNotEqualToRight_ExpectTrue(
        Failure<SomeFailureCode> left, Failure<SomeFailureCode> right)
    {
        var actual = left != right;
        Assert.True(actual);
    }
}
