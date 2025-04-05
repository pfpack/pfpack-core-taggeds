using System;
using System.Text.Json;
using PrimeFuncPack.UnitTest;
using Xunit;

namespace PrimeFuncPack.Core.Tests;

partial class OptionalJsonSerializerTest
{
    [Theory]
    [MemberData(nameof(DefaultJsonSerializerTestData))]
    public static void SerializeDefault_ExpectActualJson(
        Optional<string> source, JsonSerializerOptions? options, string expected)
    {
        var actual = JsonSerializer.Serialize(source, options);
        Assert.Equal(expected, actual);
    }

    public static TheoryData<Optional<string>, JsonSerializerOptions?, string> DefaultJsonSerializerTestData
        =>
        new()
        {
            {
                default,
                null,
                "{\"IsPresent\":false}"
            },
            {
                default,
                new(JsonSerializerDefaults.General)
                {
                    WriteIndented = true
                },
                "{\n  \"IsPresent\": false\n}"
            },
            {
                default,
                new(JsonSerializerDefaults.Web),
                "{\"isPresent\":false}"
            },
            {
                default,
                new()
                {
                    PropertyNamingPolicy = JsonNamingPolicy.KebabCaseLower
                },
                "{\"is-present\":false}"
            },
            {
                ((string)null!).InitializePresentOptional(),
                null,
                "{\"IsPresent\":true,\"Value\":null}"
            },
            {
                TestData.EmptyString.InitializePresentOptional(),
                new(JsonSerializerDefaults.General)
                {
                    WriteIndented = true
                },
                "{\n  \"IsPresent\": true,\n  \"Value\": \"\"\n}"
            },
            {
                TestData.SomeString.InitializePresentOptional(),
                new(JsonSerializerDefaults.Web),
                $"{{\"isPresent\":true,\"value\":\"{TestData.SomeString}\"}}"
            },
            {
                TestData.SomeString.InitializePresentOptional(),
                new(JsonSerializerDefaults.Web)
                {
                    PropertyNamingPolicy = JsonNamingPolicy.KebabCaseLower
                },
                $"{{\"is-present\":true,\"value\":\"{TestData.SomeString}\"}}"
            }
        };
}