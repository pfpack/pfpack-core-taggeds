using System;
using System.Text.Json;
using PrimeFuncPack.UnitTest;
using Xunit;

namespace PrimeFuncPack.Core.Tests;

partial class OptionalJsonSerializerTest
{
    [Theory]
    [MemberData(nameof(OmitableJsonSerializerOptionsTestData))]
    public static void DeserializeOmitable_SourceValueIsRefType_OptionalFieldIsAbsent_ExpectDefault(
        JsonSerializerOptions options)
    {
        const string json = "{}";
        var actual = JsonSerializer.Deserialize<RefTypeValue>(json, options);

        actual.Value.VerifyDefaultInnerState();
    }

    [Theory]
    [MemberData(nameof(OmitableStringTestData))]
    public static void DeserializeOmitable_SourceValueIsRefType_OptionalFieldIsPresent_ExpectInnerValueIsEqualToSourceValue(
        JsonSerializerOptions options, string? sourceValue)
    {
        var source = new
        {
            Value = sourceValue
        };

        var json = JsonSerializer.Serialize(source);
        var actual = JsonSerializer.Deserialize<RefTypeValue>(json, options);

        actual.Value.VerifyPresentInnerState(sourceValue);
    }

    [Theory]
    [MemberData(nameof(NullableJsonSerializerOptionsTestData))]
    public static void DeserializeOmitable_SourceValueIsStructTypeWithAttribute_OptionalFieldIsAbsent_ExpectDefault(
        JsonSerializerOptions? options)
    {
        const string json = "{}";
        var actual = JsonSerializer.Deserialize<StructTypeValue>(json, options);

        actual.Value.VerifyDefaultInnerState();
    }

    [Theory]
    [MemberData(nameof(OmitableNullableInt32TestData))]
    public static void DeserializeOmitable_SourceValueIsStructType_OptionalFieldIsPresent_ExpectInnerValueIsEqualToSourceValue(
        JsonSerializerOptions? options, int? sourceValue)
    {
        var source = new
        {
            Value = sourceValue
        };

        var json = JsonSerializer.Serialize(source);
        var actual = JsonSerializer.Deserialize<StructTypeValue>(json, options);

        actual.Value.VerifyPresentInnerState(sourceValue);
    }

    public static TheoryData<JsonSerializerOptions> OmitableJsonSerializerOptionsTestData
        =>
        new()
        {
            {
                Optional.JsonSerializerOptionsOmitableGeneral
            },
            {
                Optional.JsonSerializerOptionsOmitableWeb
            }
        };

    public static TheoryData<JsonSerializerOptions?> NullableJsonSerializerOptionsTestData
        =>
        new()
        {
            {
                null
            },
            {
                new()
            },
            {
                new(JsonSerializerDefaults.Web)
            },
            {
                Optional.JsonSerializerOptionsOmitableGeneral
            },
            {
                Optional.JsonSerializerOptionsOmitableWeb
            }
        };

    public static TheoryData<JsonSerializerOptions, string?> OmitableStringTestData
    {
        get
        {
            var data = new TheoryData<JsonSerializerOptions, string?>();
            string?[] values = [null, string.Empty, TestData.SomeString];

            foreach (var options in OmitableJsonSerializerOptionsTestData)
            {
                foreach (var value in values)
                {
                    data.Add(options, value);
                }
            }

            return data;
        }
    }

    public static TheoryData<JsonSerializerOptions?, int?> OmitableNullableInt32TestData
    {
        get
        {
            var data = new TheoryData<JsonSerializerOptions?, int?>();
            int?[] values = [null, TestData.Zero, TestData.PlusFifteen];

            foreach (var options in NullableJsonSerializerOptionsTestData)
            {
                foreach (var value in values)
                {
                    data.Add(options, value);
                }
            }

            return data;
        }
    }
}