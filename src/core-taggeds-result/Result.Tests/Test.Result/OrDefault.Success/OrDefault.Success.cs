using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using System;

namespace PrimeFuncPack.Core.Tests;

partial class ResultTest
{
    [Test]
    [TestCase(int.MinValue)]
    [TestCase(-1)]
    [TestCase(0)]
    [TestCase(1)]
    [TestCase(int.MaxValue)]
    public void SuccessOrDefault_IsSuccess_ExpectSource_Struct(int success)
    {
        var result = new Result<int, SomeError>(success);

        var actual = result.SuccessOrDefault();
        Assert.AreEqual(actual, success);
    }

    [Test]
    public void SuccessOrDefault_Default_ExpectDefault_Struct()
    {
        var result = new Result<int, SomeError>();

        var actual = result.SuccessOrDefault();
        Assert.Zero(actual);
    }

    [Test]
    public void SuccessOrDefault_IsFailure_ExpectDefault_Struct()
    {
        var result = new Result<int, SomeError>(new SomeError(1));

        var actual = result.SuccessOrDefault();
        Assert.Zero(actual);
    }

    [Test]
    public void SuccessOrDefault_IsSuccess_ExpectSource_Ref()
    {
        var refObj = new RefType { Id = 1 };
        var result = new Result<RefType, SomeError>(refObj);

        var actual = result.SuccessOrDefault();
        Assert.AreSame(actual, refObj);
    }

    [Test]
    public void SuccessOrDefault_Default_ExpectNull_Ref()
    {
        var result = new Result<RefType, SomeError>();

        var actual = result.SuccessOrDefault();
        Assert.IsNull(actual);
    }

    [Test]
    public void SuccessOrDefault_IsFailure_ExpectNull_Ref()
    {
        var result = new Result<RefType, SomeError>(new SomeError(1));

        var actual = result.SuccessOrDefault();
        Assert.IsNull(actual);
    }
}
