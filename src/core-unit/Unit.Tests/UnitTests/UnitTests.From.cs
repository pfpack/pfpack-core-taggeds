#nullable enable

using NUnit.Framework;
using System;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class UnitTests
{
    [Test]
    [TestCase(true)]
    [TestCase(false)]
    public void From_ExpectUnitValue(
        bool isResultNull)
    {
        var result = isResultNull ? null : MinusFifteenIdRefType;
        var actual = Unit.From(result);

        Assert.AreEqual(Unit.Value, actual);
    }
}
