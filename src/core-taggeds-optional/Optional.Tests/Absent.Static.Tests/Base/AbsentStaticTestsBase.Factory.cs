using NUnit.Framework;
using System;

namespace PrimeFuncPack.Core.Tests;

partial class AbsentStaticTestsBase<T>
{
    [Test]
    public void Factory_Of_ExpectEqualToDefault()
    {
        Assert.That(Absent.Of<T>(), Is.EqualTo(default(Absent<T>)));
    }

    [Test]
    public void Factory_Of_ExpectEqualToNew()
    {
        Assert.That(Absent.Of<T>(), Is.EqualTo(new Absent<T>()));
    }

    [Test]
    public void Factory_Of_ExpectEqualToValue()
    {
        Assert.That(Absent.Of<T>(), Is.EqualTo(Absent<T>.Value));
    }
}
