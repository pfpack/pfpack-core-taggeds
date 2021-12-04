using PrimeFuncPack.UnitTest;
using System;
using System.Collections.Generic;
using System.Linq;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

    internal static class TestDataSource
    {
        public static IEnumerable<object[]> SuccessNullTestSource
            =>
            new Result<RefType?, StructType>[]
            {
                Result.Success<RefType?>(null).With<StructType>(),
                (Result<RefType?, StructType>)Result.Success<RefType?>(null),
                Result<RefType?, StructType>.Success(null),
                new Result<RefType?, StructType>(null),
                (Result<RefType?, StructType>)null
            }
            .ToTestSource();

        public static IEnumerable<object[]> SuccessPlusFifteenIdRefTypeTestSource
            =>
            new Result<RefType, StructType>[]
            {
                Result.Success<RefType>(PlusFifteenIdRefType).With<StructType>(),
                (Result<RefType, StructType>)Result.Success<RefType>(PlusFifteenIdRefType),
                Result<RefType, StructType>.Success(PlusFifteenIdRefType),
                new Result<RefType, StructType>(PlusFifteenIdRefType),
                (Result<RefType, StructType>)PlusFifteenIdRefType
            }
            .ToTestSource();

        public static IEnumerable<object[]> FailureDefaultTestSource
            =>
            new Result<RefType, StructType>[]
            {
                default(Result<RefType, StructType>),
                new Result<RefType, StructType>(),
                new Result<RefType, StructType>(default(StructType)),
                (Result<RefType, StructType>)Result.Failure(default(StructType)),
                Result.Failure(default(StructType)).With<RefType>(),
                Result<RefType, StructType>.Failure(default)
            }
            .ToTestSource();
        
        public static IEnumerable<object[]> FailureSomeTextStructTypeTestSource
            =>
            new Result<RefType, StructType>[]
            {
                new Result<RefType, StructType>(SomeTextStructType),
                (Result<RefType, StructType>)Result.Failure(SomeTextStructType),
                Result.Failure(SomeTextStructType).With<RefType>(),
                Result<RefType, StructType>.Failure(SomeTextStructType)
            }
            .ToTestSource();

        public static IEnumerable<object?[]> ObjectNullableTestSource
            =>
            new object?[]
            {
                null,
                new object(),
                MinusFifteen,
                PlusFifteenIdRefType,
                SomeTextStructType
            }
            .ToNullableTestSource();
        
        private static IEnumerable<object[]> ToTestSource<T>(
            this IEnumerable<T> source)
            where T : notnull
            =>
            source.Select(
                item => new object[] { item });

        private static IEnumerable<object?[]> ToNullableTestSource(this IEnumerable<object?> source)
            =>
            source.Select(v => new[] { v });
    }
