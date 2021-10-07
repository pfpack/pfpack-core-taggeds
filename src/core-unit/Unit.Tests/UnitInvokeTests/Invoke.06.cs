#nullable enable

using Moq;
using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using PrimeFuncPack.UnitTest.Moq;
using System;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class UnitInvokeTests
{
    [Test]
    public void Invoke_06_ActionIsNull_ExpectArgumentNullException()
    {
        Action<StructType, RefType, string, int, object, DateTime> action = null!;

        var arg1 = SomeTextStructType;
        var arg2 = PlusFifteenIdRefType;
        var arg3 = TabString;
        var arg4 = MinusFortyFive;
        var arg5 = new { Value = PlusTwoHundredPointFive };
        var arg6 = Year2015March11H01Min15;

        var ex = Assert.Throws<ArgumentNullException>(() => _ = Unit.Invoke(action, arg1, arg2, arg3, arg4, arg5, arg6));
        Assert.AreEqual("action", ex!.ParamName);
    }

    [Test]
    public void Invoke_06_ExpectCallActionOnce()
    {
        var mockAction = MockActionFactory.CreateMockAction<StructType, RefType?, string, int, object?, DateTime>();

        var arg1 = SomeTextStructType;
        var arg2 = (RefType?)null;
        var arg3 = TabString;
        var arg4 = MinusFortyFive;
        var arg5 = new { Value = PlusTwoHundredPointFive };
        var arg6 = Year2015March11H01Min15;

        var actual = Unit.Invoke(mockAction.Object.Invoke, arg1, arg2, arg3, arg4, arg5, arg6);

        Assert.AreEqual(Unit.Value, actual);
        mockAction.Verify(a => a.Invoke(arg1, arg2, arg3, arg4, arg5, arg6), Times.Once);
    }
}
