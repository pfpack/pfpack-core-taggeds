using System;
using PrimeFuncPack.UnitTest;
using Xunit;

namespace PrimeFuncPack.Core.Tests;

partial class FailureTestSource
{
    public static TheoryData<Failure<EnumType>, Failure<EnumType>> EqualPairTestData
        =>
        new()
        {
            {
                new Failure<EnumType>(),
                default
            },
            {
                new Failure<EnumType>(),
                new Failure<EnumType>(default, null)
            },
            {
                default,
                new Failure<EnumType>(default, string.Empty)
                {
                    SourceException = null
                }
            },
            {
                new Failure<EnumType>(default, null),
                new Failure<EnumType>()
            },
            {
                new Failure<EnumType>(default, string.Empty),
                default
            },
            {
                new Failure<EnumType>(EnumType.One, null)
                {
                    SourceException = SomeException.Instance
                },
                new Failure<EnumType>(EnumType.One, null)
                {
                    SourceException = SomeException.Instance
                }
            },
            {
                new Failure<EnumType>(EnumType.Two, string.Empty),
                new Failure<EnumType>(EnumType.Two, null)
            },
            {
                new Failure<EnumType>(EnumType.Three, null),
                new Failure<EnumType>(EnumType.Three, string.Empty)
            },
            {
                new Failure<EnumType>(EnumType.Zero, string.Empty),
                new Failure<EnumType>(EnumType.Zero, string.Empty)
            },
            {
                new Failure<EnumType>(EnumType.One, TestData.SomeString)
                {
                    SourceException = SomeException.Instance
                },
                new Failure<EnumType>(EnumType.One, TestData.SomeString)
                {
                    SourceException = SomeException.Instance
                }
            }
        };
}