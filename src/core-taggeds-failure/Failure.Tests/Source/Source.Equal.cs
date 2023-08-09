using System;
using System.Collections.Generic;
using PrimeFuncPack.UnitTest;

namespace PrimeFuncPack.Core.Tests;

partial class FailureTestSource
{
    public static IEnumerable<object[]> EqualPairTestData
        =>
        new[]
        {
            new object[]
            {
                new Failure<SomeFailureCode>(),
                default(Failure<SomeFailureCode>)
            },
            new object[]
            {
                new Failure<SomeFailureCode>(),
                new Failure<SomeFailureCode>(default, null)
            },
            new object[]
            {
                default(Failure<SomeFailureCode>),
                new Failure<SomeFailureCode>(default, string.Empty)
                {
                    SourceException = null
                }
            },
            new object[]
            {
                new Failure<SomeFailureCode>(default, null),
                new Failure<SomeFailureCode>()
            },
            new object[]
            {
                new Failure<SomeFailureCode>(default, string.Empty),
                default(Failure<SomeFailureCode>)
            },
            new object[]
            {
                new Failure<SomeFailureCode>(SomeFailureCode.First, null)
                {
                    SourceException = SomeException.SomeInstance
                },
                new Failure<SomeFailureCode>(SomeFailureCode.First, null)
                {
                    SourceException = SomeException.SomeInstance
                }
            },
            new object[]
            {
                new Failure<SomeFailureCode>(SomeFailureCode.Second, string.Empty),
                new Failure<SomeFailureCode>(SomeFailureCode.Second, null)
            },
            new object[]
            {
                new Failure<SomeFailureCode>(SomeFailureCode.Third, null),
                new Failure<SomeFailureCode>(SomeFailureCode.Third, string.Empty)
            },
            new object[]
            {
                new Failure<SomeFailureCode>(SomeFailureCode.Unknown, string.Empty),
                new Failure<SomeFailureCode>(SomeFailureCode.Unknown, string.Empty)
            },
            new object[]
            {
                new Failure<SomeFailureCode>(SomeFailureCode.First, TestData.SomeString)
                {
                    SourceException = SomeException.SomeInstance
                },
                new Failure<SomeFailureCode>(SomeFailureCode.First, TestData.SomeString)
                {
                    SourceException = SomeException.SomeInstance
                }
            }
        };
}