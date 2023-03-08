using NUnit.Framework;
using System;

namespace PrimeFuncPack.Core.Tests;

partial class AbsentTestsBase<T>
{
    [Test]
    public void Comparison_CompareTo_NewAndDefault_ExpectZero()
    {
        var actual = new Absent<T>().CompareTo(default);
        Assert.Zero(actual);
    }

    [Test]
    public void Comparison_CompareTo_ValueAndDefault_ExpectZero()
    {
        var actual = Absent<T>.Value.CompareTo(default);
        Assert.Zero(actual);
    }

    [Test]
    public void Comparison_CompareToObj_NewAndNull_ExpectOne()
    {
        var actual = new Absent<T>().CompareTo(null);
        Assert.Positive(actual);
        Assert.AreEqual(1, actual);
    }

    [Test]
    public void Comparison_CompareToObj_ValueAndNull_ExpectOne()
    {
        var actual = Absent<T>.Value.CompareTo(null);
        Assert.Positive(actual);
        Assert.AreEqual(1, actual);
    }

    [Test]
    public void Comparison_CompareToObj_NewAndDefault_ExpectZero()
    {
        var actual = new Absent<T>().CompareTo((object?)default(Absent<T>));
        Assert.Zero(actual);
    }

    [Test]
    public void Comparison_CompareToObj_ValueAndDefault_ExpectZero()
    {
        var actual = Absent<T>.Value.CompareTo((object?)new Absent<T>());
        Assert.Zero(actual);
    }

    [Test]
    public void Comparison_CompareToObj_NewAndAnotherType_ExpectZero()
    {
        Assert.Throws<ArgumentException>(() => _ = new Absent<T>().CompareTo(new object()));
    }

    [Test]
    public void Comparison_CompareToObj_ValueAndAnotherType_ExpectZero()
    {
        Assert.Throws<ArgumentException>(() => _ = Absent<T>.Value.CompareTo(new object()));
    }
}
