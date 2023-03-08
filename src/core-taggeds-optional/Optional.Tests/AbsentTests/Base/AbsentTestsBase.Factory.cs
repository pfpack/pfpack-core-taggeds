using NUnit.Framework;
using System;

namespace PrimeFuncPack.Core.Tests;

partial class AbsentTestsBase<T>
{
    [Test]
    public void Factory_New_ExpectDefault()
    {
        Assert.AreEqual(default(Absent<T>), new Absent<T>());
    }

    [Test]
    public void Factory_Value_ExpectDefault()
    {
        Assert.AreEqual(default(Absent<T>), Absent<T>.Value);
    }
}
