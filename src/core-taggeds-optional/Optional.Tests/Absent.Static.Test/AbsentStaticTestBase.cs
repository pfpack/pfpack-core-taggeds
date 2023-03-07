using NUnit.Framework;
using System;

namespace PrimeFuncPack.Core.Tests;

public abstract class AbsentStaticTestBase<T>
{
    // Factory

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

    // Equality

    [Test]
    public void Equality_Equals_OfAndDefault_ExpectTrue()
    {
        var actual = Absent.Equals(Absent.Of<T>(), default(Absent<T>));
        Assert.True(actual);
    }

    [Test]
    public void Equality_Equals_OfAndNew_ExpectTrue()
    {
        var actual = Absent.Equals(Absent.Of<T>(), new Absent<T>());
        Assert.True(actual);
    }

    // Comparison

    [Test]
    public void Comparison_Compare_OfAndDefault_ExpectTrue()
    {
        var actual = Absent.Compare(Absent.Of<T>(), default(Absent<T>));
        Assert.Zero(actual);
    }

    [Test]
    public void Comparison_Compare_OfAndNew_ExpectTrue()
    {
        var actual = Absent.Compare(new Absent<T>(), default(Absent<T>));
        Assert.Zero(actual);
    }
}
