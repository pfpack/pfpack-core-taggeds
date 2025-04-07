using System;
using System.Text.Json;
using Xunit;

namespace PrimeFuncPack.Core.Tests;

partial class OptionalJsonSerializerTest
{
    [Theory]
    [MemberData(nameof(DefaultDeserializerAbsentTestData))]
    public static void DeserializeDefault_JsonAbsentIsFoundOrPresentIsNotFound_ExpectDefault(
        string source, JsonSerializerOptions? options)
    {
        var actual = JsonSerializer.Deserialize<Optional<State?>>(source, options);
        actual.VerifyDefaultInnerState();
    }

    [Theory]
    [MemberData(nameof(DefaultDeserializerPresentTestData))]
    public static void DeserializeDefault_JsonPresentIsFound_ExpectPresentInnerState(
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
                "{\"Absent\":false}",
                null
            },
            {
                "{\"isPresent\":false,\"absent\":{}}",
                new(JsonSerializerDefaults.Web)
            },
            {
                "{\"name\":{},\"absent\":{}}",
                new()
                {
                    PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower
                }
            },
            {
                "{\"Items\":[],\"Absent\":{}}",
                new(JsonSerializerDefaults.General)
            },
            {
                "{\"Absent\":null}",
                new(JsonSerializerDefaults.General)
            },
            {
                "{\"Absent\":[1,2,3]}",
                null
            }
        };

    public static TheoryData<string, JsonSerializerOptions?, State?> DefaultDeserializerPresentTestData
        =>
        new()
        {
            {
                "{\"Present\":null}",
                null,
                null
            },
            {
                "{\"PRESENT\":null}",
                new()
                {
                    PropertyNamingPolicy = JsonNamingPolicy.KebabCaseUpper
                },
                null
            },
            {
                "{\"Present\":{\"Value\":15}}",
                null,
                new()
                {
                    Value = 15
                }
            },
            {
                "{\"present\":{}}",
                new(JsonSerializerDefaults.Web),
                new()
                {
                    Value = null
                }
            },
            {
                "{\"Present\":null,\"isPresent\":true,\"present\":{\"value\":0}}",
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