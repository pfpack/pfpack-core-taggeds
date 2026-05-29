using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Testing;
using Microsoft.CodeAnalysis.Testing;
using PrimeFuncPack.Analyzer;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Versioning;

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
            // Add supported frameworks versions in descending order
            // to ensure the most recent compatible framework is selected.
            IEnumerable<KeyValuePair<string, ReferenceAssemblies>> supportedFrameworks =
            [
                new("v10.0", ReferenceAssemblies.Net.Net100),
            ];

            var target = Assembly.GetExecutingAssembly().GetCustomAttribute<TargetFrameworkAttribute>()
                ?? throw new InvalidOperationException($"{nameof(TargetFrameworkAttribute)} not found.");

            var frameworkName = target.FrameworkName;

            foreach (var (version, referenceAssemblies) in supportedFrameworks)
            {
                if (frameworkName.Contains(version, StringComparison.InvariantCultureIgnoreCase))
                {
                    return referenceAssemblies;
                }
            }

            throw new InvalidOperationException($"Unsupported framework: {frameworkName}");
        }
    }
}
