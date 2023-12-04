using System;
using System.Collections.Generic;
using System.Reflection;
using PrimeFuncPack.UnitTest;

namespace PrimeFuncPack.Core.Tests;

partial class FailureTestSource
{
    public static IEnumerable<object[]> ToExceptionTestData
        =>
        new[]
        {
            new object[]
            {
                default(Failure<SomeFailureCode>),
                InnerCreate(default(SomeFailureCode), null, null)
            },
            new object[]
            {
                new Failure<SomeFailureCode>(SomeFailureCode.First, null),
                InnerCreate(SomeFailureCode.First, null, null)
            },
            new object[]
            {
                new Failure<SomeFailureCode>(SomeFailureCode.Second, string.Empty),
                InnerCreate(SomeFailureCode.Second, null, null)
            },
            new object[]
            {
                new Failure<SomeFailureCode>(SomeFailureCode.Unknown, TestData.WhiteSpaceString),
                InnerCreate(SomeFailureCode.Unknown, TestData.WhiteSpaceString, null)
            },
            new object[]
            {
                new Failure<SomeFailureCode>(SomeFailureCode.Second, TestData.SomeString),
                InnerCreate(SomeFailureCode.Second, TestData.SomeString, null)
            },
            new object[]
            {
                new Failure<SomeFailureCode>(SomeFailureCode.Third, null)
                {
                    SourceException = new InvalidOperationException("Some error message")
                },
                InnerCreate(SomeFailureCode.Third, null, new InvalidOperationException("Some error message"))
            },
            new object[]
            {
                new Failure<SomeFailureCode>(SomeFailureCode.First, string.Empty)
                {
                    SourceException = new("Some Exception")
                },
                InnerCreate(SomeFailureCode.First, null, new("Some Exception"))
            },
            new object[]
            {
                new Failure<SomeFailureCode>(SomeFailureCode.First, TestData.MixedWhiteSpacesString)
                {
                    SourceException = new("Some Exception")
                },
                InnerCreate(SomeFailureCode.First, TestData.MixedWhiteSpacesString, new("Some Exception"))
            },
            new object[]
            {
                new Failure<SomeFailureCode>(SomeFailureCode.Second, TestData.AnotherString)
                {
                    SourceException = new InvalidCastException("Some error text", new SomeException())
                },
                InnerCreate(SomeFailureCode.Second, TestData.AnotherString, new InvalidCastException("Some error text", new SomeException()))
            }
        };

    private static Failure<TFailureCode>.Exception InnerCreate<TFailureCode>(
        TFailureCode failureCode, string? message, Exception? innerException)
        where TFailureCode : struct
    {
        var type = typeof(Failure<TFailureCode>.Exception);

        var constructor = typeof(Failure<TFailureCode>.Exception).GetConstructor(
            bindingAttr: BindingFlags.NonPublic | BindingFlags.Instance,
            types: new[] { typeof(TFailureCode), typeof(string), typeof(Exception) })
            ?? throw new InvalidOperationException($"Required constructor in type {type} was not found");

        return (Failure<TFailureCode>.Exception)constructor.Invoke(new object?[] { failureCode, message, innerException });
    }
}