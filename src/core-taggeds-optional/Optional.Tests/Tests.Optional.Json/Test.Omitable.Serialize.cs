using System;
using System.Text.Json;
using PrimeFuncPack.UnitTest;
using Xunit;

namespace PrimeFuncPack.Core.Tests;

partial class OptionalJsonSerializerTest
{
    [Theory]
    [MemberData(nameof(OmitableOptionalValueTestData))]
    public static void SerializeOmitable_SourceValueIsOptional_ExpectCorrectJson(
        Optional<string> source, JsonSerializerOptions options, string expected)
    {
        var actual = JsonSerializer.Serialize(source, options);
        Assert.Equal(expected, actual);
    }

    [Theory]
    [MemberData(nameof(OmitableRefTypeWithOptionsTestData))]
    public static void SerializeOmitable_SourceValueIsRefType_ExpectCorrectJson(
        RefTypeValue source, JsonSerializerOptions options, string expected)
    {
        var actual = JsonSerializer.Serialize(source, options);
        Assert.Equal(expected, actual);
    }

    [Theory]
    [MemberData(nameof(OmitableStructTypeWithAttributeTestData))]
    public static void SerializeOmitable_SourceValueIsStructType_ExpectCorrectJson(
        StructTypeValue source, JsonSerializerOptions? options, string expected)
    {
        var actual = JsonSerializer.Serialize(source, options);
        Assert.Equal(expected, actual);
    }

    public static TheoryData<Optional<string>, JsonSerializerOptions, string> OmitableOptionalValueTestData
        =>
        new()
        {
            {
                default,
                Optional.JsonSerializerOptionsOmitableGeneral,
                string.Empty
            },
            {
                default,
                Optional.JsonSerializerOptionsOmitableWeb,
                string.Empty
            },
            {
                ((string)null!).InitializePresentOptional(),
                Optional.JsonSerializerOptionsOmitableGeneral,
                "null"
            },
            {
                ((string)null!).InitializePresentOptional(),
                Optional.JsonSerializerOptionsOmitableWeb,
                "null"
            },
            {
                TestData.SomeString.InitializePresentOptional(),
                Optional.JsonSerializerOptionsOmitableGeneral,
                $"\"{TestData.SomeString}\""
            },
            {
                TestData.SomeString.InitializePresentOptional(),
                Optional.JsonSerializerOptionsOmitableWeb,
                $"\"{TestData.SomeString}\""
            }
        };

    public static TheoryData<RefTypeValue, JsonSerializerOptions, string> OmitableRefTypeWithOptionsTestData
        =>
        new()
        {
            {
                new()
                {
                    Value = default
                },
                Optional.JsonSerializerOptionsOmitableGeneral,
                "{}"
            },
            {
                new()
                {
                    Value = default
                },
                Optional.JsonSerializerOptionsOmitableWeb,
                "{}"
            },
            {
                new()
                {
                    Value = ((string)null!).InitializePresentOptional()
                },
                Optional.JsonSerializerOptionsOmitableGeneral,
                "{\"Value\":null}"
            },
            {
                new()
                {
                    Value = ((string)null!).InitializePresentOptional(),
                    ArrayValues =
                    [
                        TestData.PlusFifteen.InitializePresentOptional(),
                        default,
                        TestData.Zero.InitializePresentOptional(),
                    ]
                },
                Optional.JsonSerializerOptionsOmitableWeb,
                "{\"value\":null,\"arrayValues\":[15,0]}"
            },
            {
                new()
                {
                    Value = TestData.SomeString.InitializePresentOptional(),
                    InnerValue = new()
                    {
                        Value = ((int?)TestData.MinusFifteen).InitializePresentOptional()
                    }
                },
                Optional.JsonSerializerOptionsOmitableGeneral,
                $"{{\"Value\":\"{TestData.SomeString}\",\"InnerValue\":{{\"Value\":{TestData.MinusFifteen}}}}}"
            },
            {
                new()
                {
                    Value = TestData.SomeString.InitializePresentOptional(),
                    InnerValue = new()
                    {
                        Value = default
                    }
                },
                Optional.JsonSerializerOptionsOmitableWeb,
                $"{{\"value\":\"{TestData.SomeString}\",\"innerValue\":{{}}}}"
            }
        };

    public static TheoryData<StructTypeValue, JsonSerializerOptions?, string> OmitableStructTypeWithAttributeTestData
        =>
        new()
        {
            {
                new()
                {
                    Value = default
                },
                null,
                "{}"
            },
            {
                new()
                {
                    Value = default
                },
                Optional.JsonSerializerOptionsOmitableWeb,
                "{}"
            },
            {
                new()
                {
                    Value = ((int?)null).InitializePresentOptional()
                },
                new(),
                "{\"Value\":null}"
            },
            {
                new()
                {
                    Value = ((int?)null).InitializePresentOptional()
                },
                new(JsonSerializerDefaults.Web),
                "{\"value\":null}"
            },
            {
                new()
                {
                    Value = ((int?)TestData.PlusFifteen).InitializePresentOptional()
                },
                new(JsonSerializerDefaults.General),
                $"{{\"Value\":{TestData.PlusFifteen}}}"
            },
            {
                new()
                {
                    Value = ((int?)TestData.PlusFifteen).InitializePresentOptional()
                },
                new(Optional.JsonSerializerOptionsOmitableWeb),
                $"{{\"value\":{TestData.PlusFifteen}}}"
            }
        };
}