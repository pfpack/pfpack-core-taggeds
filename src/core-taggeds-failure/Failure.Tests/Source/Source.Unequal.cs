using System;
using System.Collections.Generic;
using PrimeFuncPack.UnitTest;

namespace PrimeFuncPack.Core.Tests;

partial class FailureTestSource
{
    public static IEnumerable<object[]> UnequalPairTestData
        =>
        new object[][]
        {
            [
                new Failure<EnumType>(),
                new Failure<EnumType>(EnumType.One, null)
            ],
            [
                default(Failure<EnumType>),
                new Failure<EnumType>(EnumType.Two, TestData.WhiteSpaceString)
            ],
            [
                new Failure<EnumType>(EnumType.Three, null),
                default(Failure<EnumType>)
            ],
            [
                new Failure<EnumType>(EnumType.One, TestData.TabString),
                new Failure<EnumType>()
            ],
            [
                new Failure<EnumType>(EnumType.One, TestData.SomeString),
                new Failure<EnumType>(EnumType.Two, TestData.SomeString)
            ],
            [
                new Failure<EnumType>(EnumType.One, TestData.SomeString)
                {
                    SourceException = SomeException.SomeInstance
                },
                new Failure<EnumType>(EnumType.One, TestData.UpperSomeString)
                {
                    SourceException = SomeException.SomeInstance
                }
            ],
            [
                new Failure<EnumType>(EnumType.One, TestData.SomeString)
                {
                    SourceException = new SomeException()
                },
                new Failure<EnumType>(EnumType.One, TestData.SomeString)
                {
                    SourceException = new SomeException()
                }
            ]
        };
}