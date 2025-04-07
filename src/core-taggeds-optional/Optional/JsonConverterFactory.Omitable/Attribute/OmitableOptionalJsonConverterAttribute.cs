using System.Text.Json.Serialization;

namespace System;

[AttributeUsage(AttributeTargets.Property)]
public class OmitableOptionalJsonConverterAttribute : JsonConverterAttribute
{
    public OmitableOptionalJsonConverterAttribute() : base(typeof(OmitableOptionalJsonConverterFactory))
    {
    }
}