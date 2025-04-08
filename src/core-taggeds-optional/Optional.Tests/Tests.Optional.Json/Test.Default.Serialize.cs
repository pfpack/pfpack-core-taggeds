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
                "{\"Absent\":{}}"
            },
            {
                default,
                new(JsonSerializerDefaults.General)
                {
                    WriteIndented = true
                },
                "{\n  \"Absent\": {}\n}"
            },
            {
                default,
                new(JsonSerializerDefaults.Web),
                "{\"absent\":{}}"
            },
            {
                default,
                new()
                {
                    PropertyNamingPolicy = JsonNamingPolicy.KebabCaseLower
                },
                "{\"absent\":{}}"
            },
            {
                ((string)null!).InitializePresentOptional(),
                null,
                "{\"Present\":null}"
            },
            {
                TestData.EmptyString.InitializePresentOptional(),
                new(JsonSerializerDefaults.General)
                {
                    WriteIndented = true
                },
                "{\n  \"Present\": \"\"\n}"
            },
            {
                TestData.SomeString.InitializePresentOptional(),
                new(JsonSerializerDefaults.Web),
                $"{{\"present\":\"{TestData.SomeString}\"}}"
            },
            {
                TestData.SomeString.InitializePresentOptional(),
                new(JsonSerializerDefaults.Web)
                {
                    PropertyNamingPolicy = JsonNamingPolicy.KebabCaseLower
                },
                $"{{\"present\":\"{TestData.SomeString}\"}}"
            }
        };
}