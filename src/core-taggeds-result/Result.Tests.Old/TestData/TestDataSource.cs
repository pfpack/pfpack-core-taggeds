﻿using PrimeFuncPack.UnitTest;
using System;
using System.Collections.Generic;
using System.Linq;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

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
        .ToTestSource();

    public static IEnumerable<object[]> SuccessNullTestSource
        =>
        new Result<RefType?, StructType>[]
        {
            Result.Success<RefType?>(null).With<StructType>(),
            Result.Success<RefType?>(null),
            Result<RefType?, StructType>.Success(null),
            new Result<RefType?, StructType>(null),
            null
        }
        .ToTestSource();

    public static IEnumerable<object[]> SuccessPlusFifteenIdRefTypeTestSource
        =>
        new Result<RefType, StructType>[]
        {
            Result.Success(PlusFifteenIdRefType).With<StructType>(),
            Result.Success(PlusFifteenIdRefType),
            Result<RefType, StructType>.Success(PlusFifteenIdRefType),
            new Result<RefType, StructType>(PlusFifteenIdRefType),
            PlusFifteenIdRefType
        }
        .ToTestSource();
        
    public static IEnumerable<object[]> SuccessMinusFifteenIdRefTypeTestSource
        =>
        new Result<RefType, StructType>[]
        {
            Result.Success(MinusFifteenIdRefType).With<StructType>(),
            Result.Success(MinusFifteenIdRefType),
            Result<RefType, StructType>.Success(MinusFifteenIdRefType),
            new Result<RefType, StructType>(MinusFifteenIdRefType),
            MinusFifteenIdRefType
        }
        .ToTestSource();

    public static IEnumerable<object[]> FailureDefaultTestSource
        =>
        new Result<RefType, StructType>[]
        {
            default,
            new Result<RefType, StructType>(),
            new Result<RefType, StructType>(default(StructType)),
            Result.Failure(default(StructType)),
            Result.Failure(default(StructType)).With<RefType>(),
            Result<RefType, StructType>.Failure(default)
        }
        .ToTestSource();
        
    public static IEnumerable<object[]> FailureSomeTextStructTypeTestSource
        =>
        new Result<RefType, StructType>[]
        {
            new Result<RefType, StructType>(SomeTextStructType),
            Result.Failure(SomeTextStructType),
            Result.Failure(SomeTextStructType).With<RefType>(),
            Result<RefType, StructType>.Failure(SomeTextStructType)
        }
        .ToTestSource();
        
    private static IEnumerable<object[]> ToTestSource<T>(
        this IEnumerable<T> source)
        where T : notnull
        =>
        source.Select(
            item => new object[] { item });
}
