using System;
using System.Collections.Generic;
using PrimeFuncPack.UnitTest;

namespace PrimeFuncPack.Core.Tests;

partial class FailureTestSource
{
    public static IEnumerable<object[]> EqualPairTestData
        =>
        new object[][]
        {
            [
                new Failure<EnumType>(),
                default(Failure<EnumType>)
            ],
            [
                new Failure<EnumType>(),
                new Failure<EnumType>(default, null)
            ],
            [
                default(Failure<EnumType>),
                new Failure<EnumType>(default, string.Empty)
                {
                    SourceException = null
                }
            ],
            [
                new Failure<EnumType>(default, null),
                new Failure<EnumType>()
            ],
            [
                new Failure<EnumType>(default, string.Empty),
                default(Failure<EnumType>)
            ],
            [
                new Failure<EnumType>(EnumType.One, null)
                {
                    SourceException = SomeException.SomeInstance
                },
                new Failure<EnumType>(EnumType.One, null)
                {
                    SourceException = SomeException.SomeInstance
                }
            ],
            [
                new Failure<EnumType>(EnumType.Two, string.Empty),
                new Failure<EnumType>(EnumType.Two, null)
            ],
            [
                new Failure<EnumType>(EnumType.Three, null),
                new Failure<EnumType>(EnumType.Three, string.Empty)
            ],
            [
                new Failure<EnumType>(EnumType.Zero, string.Empty),
                new Failure<EnumType>(EnumType.Zero, string.Empty)
            ],
            [
                new Failure<EnumType>(EnumType.One, TestData.SomeString)
                {
                    SourceException = SomeException.SomeInstance
                },
                new Failure<EnumType>(EnumType.One, TestData.SomeString)
                {
                    SourceException = SomeException.SomeInstance
                }
            ]
        };
}