using System;
using System.Collections.Generic;
using System.Reflection;
using PrimeFuncPack.UnitTest;

namespace PrimeFuncPack.Core.Tests;

partial class FailureTestSource
{
    public static IEnumerable<object[]> ToExceptionTestData
        =>
        new object[][]
        {
            [
                default(Failure<EnumType>),
                InnerCreate(default(EnumType), null, null)
            ],
            [
                new Failure<EnumType>(EnumType.One, null),
                InnerCreate(EnumType.One, null, null)
            ],
            [
                new Failure<EnumType>(EnumType.Two, string.Empty),
                InnerCreate(EnumType.Two, null, null)
            ],
            [
                new Failure<EnumType>(EnumType.Zero, TestData.WhiteSpaceString),
                InnerCreate(EnumType.Zero, TestData.WhiteSpaceString, null)
            ],
            [
                new Failure<EnumType>(EnumType.Two, TestData.SomeString),
                InnerCreate(EnumType.Two, TestData.SomeString, null)
            ],
            [
                new Failure<EnumType>(EnumType.Three, null)
                {
                    SourceException = new InvalidOperationException("Some error message")
                },
                InnerCreate(EnumType.Three, null, new InvalidOperationException("Some error message"))
            ],
            [
                new Failure<EnumType>(EnumType.One, string.Empty)
                {
                    SourceException = new("Some Exception")
                },
                InnerCreate(EnumType.One, null, new("Some Exception"))
            ],
            [
                new Failure<EnumType>(EnumType.One, TestData.MixedWhiteSpacesString)
                {
                    SourceException = new("Some Exception")
                },
                InnerCreate(EnumType.One, TestData.MixedWhiteSpacesString, new("Some Exception"))
            ],
            [
                new Failure<EnumType>(EnumType.Two, TestData.AnotherString)
                {
                    SourceException = new InvalidCastException("Some error text", new SomeException())
                },
                InnerCreate(EnumType.Two, TestData.AnotherString, new InvalidCastException("Some error text", new SomeException()))
            ]
        };

    private static Failure<TFailureCode>.Exception InnerCreate<TFailureCode>(
        TFailureCode failureCode, string? message, Exception? innerException)
        where TFailureCode : struct
    {
        var type = typeof(Failure<TFailureCode>.Exception);

        var constructor = typeof(Failure<TFailureCode>.Exception).GetConstructor(
            bindingAttr: BindingFlags.NonPublic | BindingFlags.Instance,
            types: [typeof(TFailureCode), typeof(string), typeof(Exception)])
            ?? throw new InvalidOperationException($"Required constructor in type {type} was not found");

        return (Failure<TFailureCode>.Exception)constructor.Invoke([failureCode, message, innerException]);
    }
}