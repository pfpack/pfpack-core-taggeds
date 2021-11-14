using System.Collections.Generic;

namespace PrimeFuncPack.Core.Tests;

partial class TestCaseSources
{
    public static IEnumerable<object?[]> String()
        =>
        InnerString().InnerBuildSource();

    public static IEnumerable<object?[]> BooleanNullable()
        =>
        InnerBooleanNullable().InnerBuildSource();

    public static IEnumerable<object?[]> Int32()
        =>
        InnerInt32().InnerBuildSource();

    public static IEnumerable<object?[]> RefType()
        =>
        InnerRefType().InnerBuildSource();

    public static IEnumerable<object?[]> RecordRefType()
        =>
        InnerRecordRefType().InnerBuildSource();

    public static IEnumerable<object?[]> StructType()
        =>
        InnerStructType().InnerBuildSource();
}
