using System;
using System.Reflection;
using System.Runtime.Versioning;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Testing;
using Microsoft.CodeAnalysis.Testing;
using PrimeFuncPack.Analyzer;

namespace PrimeFuncPack.Core.Tests;

public static partial class OptionalJsonConverterTypeAnalyzerTest
{
    private static CSharpAnalyzerTest<OmitableOptionalJsonConverterTypeAnalyzer, DefaultVerifier> BuildAnalyzerTest(
        string testCode, params DiagnosticResult[] expectedDiagnostics)
    {
        var analyzerTest = new CSharpAnalyzerTest<OmitableOptionalJsonConverterTypeAnalyzer, DefaultVerifier>
        {
            TestCode = testCode,
            ReferenceAssemblies = GetReferenceAssemblies(),
            TestState =
            {
                AdditionalReferences =
                {
                    MetadataReference.CreateFromFile(typeof(Optional).GetTypeInfo().Assembly.Location)
                }
            }
        };

        if (expectedDiagnostics?.Length > 0)
        {
            analyzerTest.ExpectedDiagnostics.AddRange(expectedDiagnostics);
        }

        return analyzerTest;

        static ReferenceAssemblies GetReferenceAssemblies()
        {
            var framework = Assembly.GetExecutingAssembly().GetCustomAttribute<TargetFrameworkAttribute>()?.FrameworkName;

            if (framework?.Contains("v9.0", System.StringComparison.InvariantCultureIgnoreCase) is true)
            {
                return ReferenceAssemblies.Net.Net90;
            }

            return ReferenceAssemblies.Net.Net80;
        }
    }
}