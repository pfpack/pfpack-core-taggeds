using System;

namespace PrimeFuncPack.Core.Tests;

partial class AbsentTestsBase<T>
{
    [Test]
    public void Factory_New_ExpectDefault()
    {
        Assert.That(new Absent<T>(), Is.EqualTo(default(Absent<T>)));
    }

    [Test]
    public void Factory_Value_ExpectDefault()
    {
        Assert.That(Absent<T>.Value, Is.EqualTo(default(Absent<T>)));
    }
}
