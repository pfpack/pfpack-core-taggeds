namespace System;

partial class DefaultOptionalJsonConverterFactory
{
    public override bool CanConvert(Type typeToConvert)
        =>
        typeToConvert.IsGenericType &&
        typeToConvert.GetGenericTypeDefinition() == typeof(Optional<>);
}