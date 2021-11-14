using System.Collections.Generic;

namespace PrimeFuncPack.Core.Tests;

partial class AsyncTestCaseSources
{
    public static IEnumerable<object?[]> String()
        =>
        InnerString().InnerBuildSource();

    public static IEnumerable<object?[]> BooleanNullable()
        =>
        InnerBooleanNullable().InnerBuildSource();

    public static IEnumerable<object?[]> Int32Nullable()
        =>
        InnerInt32Nullable().InnerBuildSource();

    public static IEnumerable<object?[]> RefType()
        =>
        InnerRefType().InnerBuildSource();

    public static IEnumerable<object?[]> RecordRefType()
        =>
        InnerRecordRefType().InnerBuildSource();

    public static IEnumerable<object[]> StructType()
        =>
        InnerStructType().InnerBuildSource()!;
}
