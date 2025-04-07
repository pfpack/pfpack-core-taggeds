using System.Collections.Immutable;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;

namespace PrimeFuncPack.Analyzer;

[DiagnosticAnalyzer(LanguageNames.CSharp)]
internal sealed class OmitableOptionalJsonConverterTypeAnalyzer : DiagnosticAnalyzer
{
    private const string AttributeName = "OmitableOptionalJsonConverterAttribute";

    private const int ConditionWhenWritingDefault = 2;

    private static readonly DiagnosticDescriptor PropertyMustBeOptionalRule
        =
        new(
            id: "PFPack001",
            title: "Property must be of type Optional<T>",
            messageFormat: $"Property '{{0}}' has {AttributeName} but is not of type Optional<T>",
            category: "Usage",
            defaultSeverity: DiagnosticSeverity.Error,
            isEnabledByDefault: true,
            description: $"Properties using {AttributeName} must be Optional<T>.");

    private static readonly DiagnosticDescriptor JsonIgnoreRequiredRule
        =
        new(
            id: "PFPack002",
            title: "JsonIgnore attribute required",
            messageFormat: $"Property '{{0}}' must have [JsonIgnore(Condition = WhenWritingDefault)] when using {AttributeName}",
            category: "Usage",
            defaultSeverity: DiagnosticSeverity.Error,
            isEnabledByDefault: true,
            description: $"Properties using {AttributeName} must also be decorated with [JsonIgnore(Condition = WhenWritingDefault)].");

    public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics
        =>
        [PropertyMustBeOptionalRule, JsonIgnoreRequiredRule];

    public override void Initialize(AnalysisContext context)
    {
        context.EnableConcurrentExecution();
        context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.None);

        context.RegisterSymbolAction(AnalyzeProperty, SymbolKind.Property);
    }

    private void AnalyzeProperty(SymbolAnalysisContext context)
    {
        if (context.Symbol is not IPropertySymbol property || property.GetAttributes().Any(IsOmitableOptionalJsonConverterAttribute) is false)
        {
            return;
        }

        if (IsOptionalType(property.Type) is false)
        {
            var diagnostic = Diagnostic.Create(PropertyMustBeOptionalRule, property.Locations[0], property.Name);
            context.ReportDiagnostic(diagnostic);

            return;
        }

        if (IsJsonIgnoreDecorated(property) is false)
        {
            var diagnostic = Diagnostic.Create(JsonIgnoreRequiredRule, property.Locations[0], property.Name);
            context.ReportDiagnostic(diagnostic);

            return;
        }

        static bool IsOmitableOptionalJsonConverterAttribute(AttributeData attribute)
            =>
            attribute.AttributeClass?.IsAnyType("System", AttributeName) is true;

        static bool IsOptionalType(ITypeSymbol propertyType)
            =>
            propertyType is INamedTypeSymbol type && type.TypeArguments.Length is 1 && type.IsAnyType("System", "Optional");
    }

    private static bool IsJsonIgnoreDecorated(IPropertySymbol property)
    {
        var jsonIgnoreAttribute = property.GetAttributes().FirstOrDefault(IsJsonIgnoreAttribute);
        return jsonIgnoreAttribute?.GetNamedArgumentValue<int?>("Condition") is ConditionWhenWritingDefault;

        static bool IsJsonIgnoreAttribute(AttributeData attribute)
            =>
            attribute.AttributeClass?.IsAnyType("System.Text.Json.Serialization", "JsonIgnoreAttribute") is true;
    }
}