using System.Reflection;
using System.Text.Json.Serialization.Metadata;

namespace System;

partial class OmitableOptionalJsonConverterFactory
{
    internal static void SkipAbsent(JsonTypeInfo typeInfo)
    {
        if (typeInfo.Kind is not JsonTypeInfoKind.Object)
        {
            return;
        }

        foreach (JsonPropertyInfo property in typeInfo.Properties)
        {
            var propertyType = property.PropertyType;
            if (propertyType.IsGenericType is false || propertyType.GetGenericTypeDefinition() != typeof(Optional<>))
            {
                continue;
            }

            var hasValueField = propertyType.GetField("hasValue", BindingFlags.Instance | BindingFlags.NonPublic);
            if (hasValueField is null)
            {
                continue;
            }

            property.ShouldSerialize = InnerShouldSerialize;

            bool InnerShouldSerialize(object _, object? value)
                =>
                hasValueField.GetValue(value) is true;
        }
    }
}