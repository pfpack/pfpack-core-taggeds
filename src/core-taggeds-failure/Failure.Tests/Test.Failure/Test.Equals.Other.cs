using System;
using Xunit;

namespace PrimeFuncPack.Core.Tests;

partial class FailureTest
{
    [Theory]
    [MemberData(nameof(FailureTestSource.EqualPairTestData), MemberType = typeof(FailureTestSource))]
    public static void EqualsOther_SourceIsEqualToOther_ExpectTrue(
        Failure<SomeFailureCode> source, Failure<SomeFailureCode> other)
    {
        var actual = source.Equals(other);
        Assert.True(actual);
    }

    [Theory]
    [MemberData(nameof(FailureTestSource.UnequalPairTestData), MemberType = typeof(FailureTestSource))]
    public static void EqualsOther_SourceIsNotEqualToOther_ExpectFalse(
        Failure<SomeFailureCode> source, Failure<SomeFailureCode> other)
    {
        var actual = source.Equals(other);
        Assert.False(actual);
    }
}
