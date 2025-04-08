using System;
using System.Reflection;

namespace PrimeFuncPack.Core.Tests;

internal static partial class TestHelper
{
    private static T GetStructFieldValue<T>(this object source, string fieldName)
        where T : struct
        =>
        source.GetType().GetInnerFieldInfoOrThrow(fieldName).GetValue(source) switch
        {
            T fieldValue => fieldValue,
            var unexpected => throw new InvalidOperationException($"An unexpected field '{fieldName}' value: {unexpected}")
        };

    private static T? GetFieldValue<T>(this object source, string fieldName)
        =>
        (T?)source.GetType().GetInnerFieldInfoOrThrow(fieldName).GetValue(source);

    private static void SetFieldValue<T>(this object source, string fieldName, T fieldValue)
        =>
        source.GetType().GetInnerFieldInfoOrThrow(fieldName).SetValue(source, fieldValue);

    private static FieldInfo GetInnerFieldInfoOrThrow(this Type type, string fieldName)
        =>
        type.GetField(fieldName, BindingFlags.Instance | BindingFlags.NonPublic)
        ?? throw new InvalidOperationException($"An inner field '{fieldName}' of the {nameof(Optional)}<T> type was not found");
}