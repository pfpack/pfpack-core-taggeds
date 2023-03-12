using NUnit.Framework;
using System;

namespace PrimeFuncPack.Core.Tests;

partial class AbsentStaticTestsBase<T>
{
    [Test]
    public void Factory_Of_ExpectEqualToDefault()
    {
        Assert.AreEqual(default(Absent<T>), Absent.Of<T>());
    }

    [Test]
    public void Factory_Of_ExpectEqualToNew()
    {
        Assert.AreEqual(new Absent<T>(), Absent.Of<T>());
    }

    [Test]
    public void Factory_Of_ExpectEqualToValue()
    {
        Assert.AreEqual(Absent<T>.Value, Absent.Of<T>());
    }
}
