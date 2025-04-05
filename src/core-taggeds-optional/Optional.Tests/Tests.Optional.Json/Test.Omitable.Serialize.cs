using System;
using System.Text.Json;
using PrimeFuncPack.UnitTest;
using Xunit;

namespace PrimeFuncPack.Core.Tests;

partial class OptionalJsonSerializerTest
{
    [Theory]
    [MemberData(nameof(OmitableValueOptionalTestData))]
    public static void SerializeOmitable_SourceValueIsOptional_ExpectCorrectJson(
        Optional<string> source, JsonSerializerOptions options, string expected)
    {
        var actual = JsonSerializer.Serialize(source, options);
        Assert.Equal(expected, actual);
    }

    [Theory]
    [MemberData(nameof(OmitableValueRefTypeTestData))]
    public static void SerializeOmitable_SourceValueIsRefType_ExpectCorrectJson(
        RefTypeValue source, JsonSerializerOptions options, string expected)
    {
        var actual = JsonSerializer.Serialize(source, options);
        Assert.Equal(expected, actual);
    }

    [Theory]
    [MemberData(nameof(OmitableValueStructTypeTestData))]
    public static void SerializeOmitable_SourceValueIsStructType_ExpectCorrectJson(
        StructTypeValue source, JsonSerializerOptions options, string expected)
    {
        var actual = JsonSerializer.Serialize(source, options);
        Assert.Equal(expected, actual);
    }

    public static TheoryData<Optional<string>, JsonSerializerOptions, string> OmitableValueOptionalTestData
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

    public static TheoryData<RefTypeValue, JsonSerializerOptions, string> OmitableValueRefTypeTestData
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

    public static TheoryData<StructTypeValue, JsonSerializerOptions, string> OmitableValueStructTypeTestData
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
                    Value = ((int?)null).InitializePresentOptional()
                },
                Optional.JsonSerializerOptionsOmitableGeneral,
                "{\"Value\":null}"
            },
            {
                new()
                {
                    Value = ((int?)null).InitializePresentOptional()
                },
                Optional.JsonSerializerOptionsOmitableWeb,
                "{\"value\":null}"
            },
            {
                new()
                {
                    Value = ((int?)TestData.PlusFifteen).InitializePresentOptional()
                },
                Optional.JsonSerializerOptionsOmitableGeneral,
                $"{{\"Value\":{TestData.PlusFifteen}}}"
            },
            {
                new()
                {
                    Value = ((int?)TestData.PlusFifteen).InitializePresentOptional()
                },
                Optional.JsonSerializerOptionsOmitableWeb,
                $"{{\"value\":{TestData.PlusFifteen}}}"
            }
        };
}