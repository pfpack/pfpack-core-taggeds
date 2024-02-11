using System;
using PrimeFuncPack.UnitTest;
using Xunit;

namespace PrimeFuncPack.Core.Tests;

partial class FailureTestSource
{
    public static TheoryData<Failure<EnumType>, Failure<EnumType>> UnequalPairTestData
        =>
        new()
        {
            {
                new Failure<EnumType>(),
                new Failure<EnumType>(EnumType.One, null)
            },
            {
                default,
                new Failure<EnumType>(EnumType.Two, TestData.WhiteSpaceString)
            },
            {
                new Failure<EnumType>(EnumType.Three, null),
                default
            },
            {
                new Failure<EnumType>(EnumType.One, TestData.TabString),
                new Failure<EnumType>()
            },
            {
                new Failure<EnumType>(EnumType.One, TestData.SomeString),
                new Failure<EnumType>(EnumType.Two, TestData.SomeString)
            },
            {
                new Failure<EnumType>(EnumType.One, TestData.SomeString)
                {
                    SourceException = SomeException.Instance
                },
                new Failure<EnumType>(EnumType.One, TestData.UpperSomeString)
                {
                    SourceException = SomeException.Instance
                }
            },
            {
                new Failure<EnumType>(EnumType.One, TestData.SomeString)
                {
                    SourceException = new SomeException()
                },
                new Failure<EnumType>(EnumType.One, TestData.SomeString)
                {
                    SourceException = new SomeException()
                }
            }
        };
}