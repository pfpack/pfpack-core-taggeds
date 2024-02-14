using System;

namespace PrimeFuncPack.Core.Tests;

partial class AbsentTestsBase<T>
{
    [Test]
    public void Comparison_CompareTo_NewAndDefault_ExpectZero()
    {
        var actual = new Absent<T>().CompareTo(default);
        Assert.That(actual, Is.Zero);
    }

    [Test]
    public void Comparison_CompareTo_ValueAndDefault_ExpectZero()
    {
        var actual = Absent<T>.Value.CompareTo(default);
        Assert.That(actual, Is.Zero);
    }

    [Test]
    public void Comparison_CompareToObj_NewAndNull_ExpectOne()
    {
        var actual = new Absent<T>().CompareTo(null);
        Assert.That(actual, Is.Positive);
        Assert.That(actual, Is.EqualTo(1));
    }

    [Test]
    public void Comparison_CompareToObj_ValueAndNull_ExpectOne()
    {
        var actual = Absent<T>.Value.CompareTo(null);
        Assert.That(actual, Is.Positive);
        Assert.That(actual, Is.EqualTo(1));
    }

    [Test]
    public void Comparison_CompareToObj_NewAndDefault_ExpectZero()
    {
        var actual = new Absent<T>().CompareTo((object?)default(Absent<T>));
        Assert.That(actual, Is.Zero);
    }

    [Test]
    public void Comparison_CompareToObj_ValueAndDefault_ExpectZero()
    {
        var actual = Absent<T>.Value.CompareTo((object?)new Absent<T>());
        Assert.That(actual, Is.Zero);
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
