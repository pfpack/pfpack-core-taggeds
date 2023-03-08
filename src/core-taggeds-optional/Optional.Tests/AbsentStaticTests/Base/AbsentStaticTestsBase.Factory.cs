using NUnit.Framework;
using System;

namespace PrimeFuncPack.Core.Tests;

partial class AbsentStaticTestsBase<T>
{
    [Test]
    public void Factory_Of_ExpectDefault()
    {
        Assert.AreEqual(default(Absent<T>), Absent.Of<T>());
    }

    [Test]
    public void Factory_Of_ExpectNew()
    {
        Assert.AreEqual(new Absent<T>(), Absent.Of<T>());
    }
}
