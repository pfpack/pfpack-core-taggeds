using System;
using System.Text.Json;
using Xunit;

namespace PrimeFuncPack.Core.Tests;

partial class OptionalJsonSerializerTest
{
    [Theory]
    [MemberData(nameof(DefaultDeserializerAbsentTestData))]
    public static void DeserializeDefault_JsonIsPresentIsNotTrue_ExpectDefault(
        string source, JsonSerializerOptions? options)
    {
        var actual = JsonSerializer.Deserialize<Optional<State?>>(source, options);
        actual.VerifyDefaultInnerState();
    }

    [Theory]
    [MemberData(nameof(DefaultDeserializerPresentTestData))]
    public static void DeserializeDefault_JsonIsPresentIsTrue_ExpectPresentInnerState(
        string source, JsonSerializerOptions? options, State? state)
    {
        var actual = JsonSerializer.Deserialize<Optional<State?>>(source, options);
        actual.VerifyPresentInnerState(state);
    }

    public static TheoryData<string, JsonSerializerOptions?> DefaultDeserializerAbsentTestData
        =>
        new()
        {
            {
                "null",
                null
            },
            {
                "null",
                new(JsonSerializerDefaults.Web)
            },
            {
                "{}",
                null
            },
            {
                "{}",
                new(JsonSerializerDefaults.Web)
            },
            {
                "{\"IsPresent\":false}",
                null
            },
            {
                "{\"isPresent\":false,\"value\":{}}",
                new(JsonSerializerDefaults.Web)
            },
            {
                "{\"name\":{},\"is_present\":false}",
                new()
                {
                    PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower
                }
            },
            {
                "{\"isPresent\":true,\"Items\":[],\"IsPresent\":false}",
                new(JsonSerializerDefaults.General)
            },
        };

    public static TheoryData<string, JsonSerializerOptions?, State?> DefaultDeserializerPresentTestData
        =>
        new()
        {
            {
                "{\"IsPresent\":true}",
                null,
                null
            },
            {
                "{\"VALUE\":null,\"IS-PRESENT\":true}",
                new()
                {
                    PropertyNamingPolicy = JsonNamingPolicy.KebabCaseUpper
                },
                null
            },
            {
                "{\"IsPresent\":true,\"Value\":{\"Value\":15}}",
                null,
                new()
                {
                    Value = 15
                }
            },
            {
                "{\"value\":{},\"isPresent\":true}",
                new(JsonSerializerDefaults.Web),
                new()
                {
                    Value = null
                }
            },
            {
                "{\"Value\":null,\"isPresent\":true,\"value\":{\"value\":0}}",
                new(JsonSerializerDefaults.Web),
                new()
                {
                    Value = 0
                }
            }
        };

    public sealed record class State
    {
        public int? Value { get; init; }
    }
}