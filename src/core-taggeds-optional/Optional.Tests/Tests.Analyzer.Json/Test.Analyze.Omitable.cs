using System.Threading.Tasks;
using Microsoft.CodeAnalysis.Testing;
using PrimeFuncPack.UnitTest;
using Xunit;

namespace PrimeFuncPack.Core.Tests;

partial class OptionalJsonConverterTypeAnalyzerTest
{
    [Fact]
    public static async Task AnalyzeOmitableJsonConverter_PropertyTypeIsNotOptional_ExpectError()
    {
        const string testCode = """
        using System;

        namespace PrimeFuncPack.Core.Tests;

        public sealed record class SomeType
        {
            [OmitableOptionalJsonConverter]
            public string? {|#0:Name|} { get; init; }
        }
        """;

        var expected = DiagnosticResult.CompilerError("PFPack001").WithLocation(0).WithArguments("Name");
        await BuildAnalyzerTest(testCode, expected).RunAsync();
    }

    [Fact]
    public static async Task AnalyzeOmitableJsonConverter_JsonIgnoreIsNotSpecified_ExpectError()
    {
        const string testCode = """
        using System;

        namespace PrimeFuncPack.Core.Tests;

        public sealed record class SomeType
        {
            [OmitableOptionalJsonConverter]
            public Optional<string?> {|#0:Name|} { get; init; }
        }
        """;

        var expected = DiagnosticResult.CompilerError("PFPack002").WithLocation(0).WithArguments("Name");
        await BuildAnalyzerTest(testCode, expected).RunAsync();
    }

    [Theory]
    [InlineData(TestData.EmptyString)]
    [InlineData("Condition = JsonIgnoreCondition.Never")]
    [InlineData("Condition = JsonIgnoreCondition.Always")]
    [InlineData("Condition = JsonIgnoreCondition.WhenWritingNull")]
    public static async Task AnalyzeOmitableJsonConverter_JsonIgnoreIsNotValid_ExpectError(
        string conditionCode)
    {
        var testCode = $$"""
        using System;
        using System.Text.Json.Serialization;

        namespace PrimeFuncPack.Core.Tests;

        public sealed record class SomeType
        {
            public Optional<string?> Name { get; init; }

            [OmitableOptionalJsonConverter]
            [JsonIgnore({{conditionCode}})]
            public Optional<int> {|#0:Id|} { get; init; }
        }
        """;

        var expected = DiagnosticResult.CompilerError("PFPack002").WithLocation(0).WithArguments("Id");
        await BuildAnalyzerTest(testCode, expected).RunAsync();
    }

    [Fact]
    public static async Task AnalyzeOmitableJsonConverter_JsonIgnoreIsValid_ExpectNoError()
    {
        const string testCode = """
        using System;
        using System.Text.Json.Serialization;

        namespace PrimeFuncPack.Core.Tests;

        public sealed record class SomeType
        {
            [OmitableOptionalJsonConverter]
            [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
            public Optional<int> {|#0:Id|} { get; init; }
        }
        """;

        await BuildAnalyzerTest(testCode).RunAsync();
    }
}