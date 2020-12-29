#nullable enable

using PrimeFuncPack.UnitTest;
using System;
using System.Collections.Generic;
using System.Linq;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Taggeds.Tests
{
    internal static class TestDataSource
    {
        public static IEnumerable<object[]> ResultTestSource
            =>
            new Result<RefType, StructType>[]
            {
                Result<RefType, StructType>.Success(PlusFifteenIdRefType),
                Result<RefType, StructType>.Failure(SomeTextStructType),
                default
            }
            .Select(
                r => new object[] { r });
    }
}
