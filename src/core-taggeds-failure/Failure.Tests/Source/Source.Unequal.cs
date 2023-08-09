using System;
using System.Collections.Generic;
using PrimeFuncPack.UnitTest;

namespace PrimeFuncPack.Core.Tests;

partial class FailureTestSource
{
    public static IEnumerable<object[]> UnequalPairTestData
        =>
        new[]
        {
            new object[]
            {
                new Failure<SomeFailureCode>(),
                new Failure<SomeFailureCode>(SomeFailureCode.First, null)
            },
            new object[]
            {
                default(Failure<SomeFailureCode>),
                new Failure<SomeFailureCode>(SomeFailureCode.Second, TestData.WhiteSpaceString)
            },
            new object[]
            {
                new Failure<SomeFailureCode>(SomeFailureCode.Third, null),
                default(Failure<SomeFailureCode>)
            },
            new object[]
            {
                new Failure<SomeFailureCode>(SomeFailureCode.First, TestData.TabString),
                new Failure<SomeFailureCode>()
            },
            new object[]
            {
                new Failure<SomeFailureCode>(SomeFailureCode.First, TestData.SomeString),
                new Failure<SomeFailureCode>(SomeFailureCode.Second, TestData.SomeString)
            },
            new object[]
            {
                new Failure<SomeFailureCode>(SomeFailureCode.First, TestData.SomeString)
                {
                    SourceException = SomeException.SomeInstance
                },
                new Failure<SomeFailureCode>(SomeFailureCode.First, TestData.UpperSomeString)
                {
                    SourceException = SomeException.SomeInstance
                }
            },
            new object[]
            {
                new Failure<SomeFailureCode>(SomeFailureCode.First, TestData.SomeString)
                {
                    SourceException = new SomeException()
                },
                new Failure<SomeFailureCode>(SomeFailureCode.First, TestData.SomeString)
                {
                    SourceException = new SomeException()
                }
            }
        };
}