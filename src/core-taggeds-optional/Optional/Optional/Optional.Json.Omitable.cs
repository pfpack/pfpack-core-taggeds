using System.Text.Json;
using System.Text.Json.Serialization.Metadata;

namespace System;

partial class Optional
{
    public static readonly JsonSerializerOptions JsonSerializerOptionsOmitableGeneral
        =
        InnerJsonSerializerOptionsOmitable.General;

    public static readonly JsonSerializerOptions JsonSerializerOptionsOmitableWeb
        =
        InnerJsonSerializerOptionsOmitable.Web;

    private static class InnerJsonSerializerOptionsOmitable
    {
        internal static readonly JsonSerializerOptions General
            =
            BuildReadOnlyOptions(JsonSerializerDefaults.General);

        internal static readonly JsonSerializerOptions Web
            =
            BuildReadOnlyOptions(JsonSerializerDefaults.Web);

        private static JsonSerializerOptions BuildReadOnlyOptions(JsonSerializerDefaults defaults)
        {
            var options = new JsonSerializerOptions(defaults)
            {
                TypeInfoResolver = new DefaultJsonTypeInfoResolver
                {
                    Modifiers =
                    {
                        OmitableOptionalJsonConverterFactory.SkipAbsent
                    }
                },
                Converters =
                {
                    new OmitableOptionalJsonConverterFactory()
                }
            };

            options.MakeReadOnly();
            return options;
        }
    }
}