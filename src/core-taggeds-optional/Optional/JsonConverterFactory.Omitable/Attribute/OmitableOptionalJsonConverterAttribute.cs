using System.Text.Json.Serialization;

namespace System;

[AttributeUsage(AttributeTargets.Property)]
public sealed class OmitableOptionalJsonConverterAttribute : JsonConverterAttribute
{
    public OmitableOptionalJsonConverterAttribute() : base(typeof(OmitableOptionalJsonConverterFactory))
    {
    }
}