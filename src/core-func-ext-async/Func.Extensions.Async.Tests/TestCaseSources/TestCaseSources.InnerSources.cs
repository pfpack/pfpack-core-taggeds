#nullable enable

using PrimeFuncPack.UnitTest;
using System.Collections.Generic;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class TestCaseSources
{
    private static IEnumerable<string?> InnerString()
    {
        yield return null;
        yield return EmptyString;
        yield return WhiteSpaceString;
        yield return TwoWhiteSpacesString;
        yield return ThreeWhiteSpacesString;
        yield return TabString;
        yield return TwoTabsString;
        yield return MixedWhiteSpacesString;
        yield return SomeString;
        yield return LowerSomeString;
        yield return UpperSomeString;
    }

    private static IEnumerable<bool?> InnerBooleanNullable()
    {
        yield return null;
        yield return true;
        yield return false;
    }

    private static IEnumerable<int?> InnerInt32Nullable()
    {
        yield return null;
        yield return int.MinValue;
        yield return MinusFifteen;
        yield return MinusOne;
        yield return Zero;
        yield return One;
        yield return PlusFifteen;
        yield return int.MaxValue;
    }

    private static IEnumerable<RefType?> InnerRefType()
    {
        yield return null;
        yield return MinusFifteenIdRefType;
        yield return PlusFifteenIdRefType;
    }

    private static IEnumerable<RecordType?> InnerRecordRefType()
    {
        yield return null;
        yield return ZeroIdNullNameRecord;
        yield return MinusFifteenIdNullNameRecord;
        yield return PlusFifteenIdSomeStringNameRecord;
    }

    private static IEnumerable<StructType> InnerStructType()
    {
        yield return default;
        yield return NullTextStructType;
        yield return SomeTextStructType;
        yield return LowerSomeTextStructType;
    }
}
